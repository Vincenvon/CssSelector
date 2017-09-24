using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CssSelector.UI.CustomViewEngine
{
    public class CustomView:IView
    {
        private string content;

        public CustomView(object obj)
        {
            this.content = obj.ToString();
        }

        public void Render(ViewContext context, TextWriter textWriter)
        {
            textWriter.Write(this.content);
        }
    }
}