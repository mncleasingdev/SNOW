using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXMNCGUI_SNOW.Tools
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DefaultStringAttribute : Attribute
    {
        private string myText;

        public string Text
        {
            get
            {
                return this.myText;
            }
        }

        public DefaultStringAttribute(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            else
                this.myText = text;
        }
    }
}