using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CssSelector.BL.HtmlPageDocument;
using System.Net.Http;
using CssSelector.BL.Service;
using CssSelector.Common.Entities;
using CssSelector.UI.Models;

namespace CssSelector.UI.Controllers
{
    public class HomeController : Controller
    {
        private IHtmlPageDocument _htmlPageDocument;
        private string SessionNameDocument = ConfigurationManager.AppSettings["SessionNameDocument"];
        private IDataBaseService _service;
        public HomeController(IHtmlPageDocument htmlPageDocument, IDataBaseService service)
        {
            _htmlPageDocument = htmlPageDocument;
            _service= service;
        }

        [HttpGet]
        public ActionResult Frame(string url = "https://www.onliner.by/")
        {
            //TODO:FIX THIS SHIT
            if (Session[SessionNameDocument] == null)
            {
                var request = HttpWebRequest.CreateHttp(url);
                var response = (HttpWebResponse) request.GetResponse();
                var stream = response.GetResponseStream();
                MemoryStream streamMemoryStream = new MemoryStream();
                stream.CopyTo(streamMemoryStream);
                streamMemoryStream.Position = 0;
                _htmlPageDocument.InitDocument(streamMemoryStream);
                var str =
                    _htmlPageDocument.GetElementByXPath(
                        "/html[1]/body[1]/div[1]/div[1]/div[2]/header[1]/div[1]/div[1]/nav[1]/ul[1]/li[1]/a[1]/span[1]");//TODO:DELETE AFTER TEST
                Session[SessionNameDocument] = _htmlPageDocument;
                this._htmlPageDocument.TestMethod("//script");
                this._htmlPageDocument.AddHtmlToDocument("//head",
                    "<script src='/Scripts/Subscriptor/Selector.js'></script>");
                this._htmlPageDocument.AddHtmlToDocument("//head",
                    "<script src='/Scripts/Subscriptor/Subscriptor.js'></script>");
                this._htmlPageDocument.AddHtmlToDocument("//head", "<link href='/Content/Site.css'rel='stylesheet'/>");
                this._htmlPageDocument.AddHtmlToDocument("//head", "<script src='/Scripts/jquery-1.10.2.js'></script>");
                this._htmlPageDocument.AddClassToElements("//body", "testCssClass");
                this._htmlPageDocument.AddIdToAllElements("//body");
                this._htmlPageDocument.SaveDocument();
                return View("Frame", null, this._htmlPageDocument.GetAsString());
            }
            else
            {
                _htmlPageDocument= (IHtmlPageDocument)Session[SessionNameDocument];
                return View("Frame", null, this._htmlPageDocument.GetAsString());
            }
        }

        [HttpPost]
        public HttpRequestMessage SaveElement(ElementModel model)
        {
            var document = (IHtmlPageDocument) Session[SessionNameDocument];
            var elementEntity = new ElementEntity
            {
               TagName = model.TagName,
               XPath = document.GetXpathElement(model.ElementId),
               Value = document.GetHashObjectValue(document.GetXpathElement(model.ElementId)/*TODO FIX*/)
            };
            _service.Insert(elementEntity);
            return null;
        }


    }
}