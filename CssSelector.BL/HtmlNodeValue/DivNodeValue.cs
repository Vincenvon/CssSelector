using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CssSelector.BL.HtmlNodeValue
{
    public class DivNodeValue: HtmlNodeValueBase
    {
        public override string GetValue()
        {
            var dataString = this.HtmlNode.InnerHtml;
            return System.Text.Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(dataString)));
        }
    }
}
