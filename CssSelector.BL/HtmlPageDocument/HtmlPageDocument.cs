using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.HtmlNodeValue;
using HtmlAgilityPack;

namespace CssSelector.BL.HtmlPageDocument
{
    public class HtmlPageDocument : IHtmlPageDocument
    {
        private HtmlDocument _htmlDocument;
        private IHtmlNodeValue _htmlNodeValue;

        public void InitDocument(Stream stream)
        {
            this._htmlDocument = new HtmlDocument();
            _htmlDocument.OptionUseIdAttribute = true;
            this._htmlDocument.Load(stream, Encoding.UTF8);
        }
        public string GetAsString()
        {
            var document = this._htmlDocument.DocumentNode.SelectSingleNode("//html").WriteContentTo();
            return document;
        }
        public void AddHtmlToDocument(string parentNodeXpath, string html)
        {
            var parentElement = this._htmlDocument.DocumentNode.SelectSingleNode(parentNodeXpath);
            parentElement.InnerHtml += html;
        }
        public void AddClassToElements(string parentNodeXpath, string className)
        {
            var parentNode = this._htmlDocument.DocumentNode.SelectSingleNode(parentNodeXpath);
            parentNode.AddClass(className);
            var children = parentNode.ChildNodes;
            foreach (var node in children)
            {
                if (node.NodeType == HtmlNodeType.Element)
                {
                    this.AddClassToElements(node.XPath, className);
                }
            }
        }
        public string GetXpathElement(string elementId)
        {
            var element = this._htmlDocument.GetElementbyId(elementId);
            return element.XPath;
        }

        public void AddIdToAllElements(string parentNodeXpath)
        {
            var parentNode = this._htmlDocument.DocumentNode.SelectSingleNode(parentNodeXpath);
            if (parentNode.NodeType == HtmlNodeType.Element)
            {
                if (string.IsNullOrEmpty(parentNode.Id))
                {
                    parentNode.SetAttributeValue("id", Guid.NewGuid().ToString());
                }
                var children = parentNode.ChildNodes;
                foreach (var node in children)
                {
                    if (node.NodeType == HtmlNodeType.Element)
                    {
                        this.AddIdToAllElements(node.XPath);
                    }
                }

            }

        }

        public void TestMethod(string tagName)
        {
            var nodes=this._htmlDocument.DocumentNode.SelectNodes(tagName);
            foreach (var node in nodes)
            {
                node.SetAttributeValue("src", "#");
                node.InnerHtml=String.Empty;
            }

        }

        public void SaveDocument()
        {
            var stream=new MemoryStream();
            this._htmlDocument.Save(stream);
            stream.Position = 0;
            this.InitDocument(stream);
        }

        public string GetElementByXPath(string XPath)
        {
            return this._htmlDocument.DocumentNode.SelectSingleNode(XPath).ToString();
        }

        public string GetHashObjectValue(string XPath)
        {
            this._htmlNodeValue=HtmlNodeValueFactory.HtmlNodeValueFactory.GetHtmlNodeValue(
                this._htmlDocument.DocumentNode.SelectSingleNode(XPath));
            return this._htmlNodeValue.GetValue();
        }


    }
}
