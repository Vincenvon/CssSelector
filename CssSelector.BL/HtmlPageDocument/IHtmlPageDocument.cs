using System.Collections.Generic;
using System.IO;

namespace CssSelector.BL.HtmlPageDocument
{
    public interface IHtmlPageDocument
    {
        void InitDocument(Stream stream);
        string GetAsString();
        void AddHtmlToDocument(string parentNodeXpath, string html);
        void AddClassToElements(string parentNodeXpath, string className);
        string GetXpathElement(string elementId);
        void AddIdToAllElements(string parentNodeXpath);
        //TODO:Rename after test
        void TestMethod(string tagName);

        //TODO:Change after test
        void SaveDocument();

        //TODO : Delete After Test

        string GetElementByXPath(string XPath);


        string GetHashObjectValue(string XPath);
    }
}
