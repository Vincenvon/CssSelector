using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CssSelector.BL.HtmlNodeValue
{
    public class HtmlNodeValueBase:IHtmlNodeValue
    {
        public HtmlNode HtmlNode {protected get; set;}

        public virtual string GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
