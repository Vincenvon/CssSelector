using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.BL.HtmlNodeValue;
using HtmlAgilityPack;

namespace CssSelector.BL.HtmlNodeValueFactory
{
    public static class HtmlNodeValueFactory
    {
        private static Dictionary<string, Type> _dictionary=new Dictionary<string, Type>
        {
            {"div",typeof(DivNodeValue)}
        };


        public static IHtmlNodeValue GetHtmlNodeValue(HtmlNode htmlNode)
        {
            //TODO :Change code,Fix exception
            var hmlNodeValue = (HtmlNodeValueBase)_dictionary["div"/*htmlNode.Name*//*TODO CHANGE */].GetConstructor(new Type[]{}).Invoke(new Object[]{});
            hmlNodeValue.HtmlNode = htmlNode;
            return hmlNodeValue;
        }
    }
}
