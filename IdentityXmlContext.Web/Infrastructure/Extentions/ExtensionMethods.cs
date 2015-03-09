using IdentityXmlContext.Model;
using IdentityXmlContext.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityXmlContext.Web.Infrastructure.Extentions
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString SetUserData(this HtmlHelper html,LoginViewModel user)
        {
            var builder = new TagBuilder("label");
            builder.MergeAttribute("value", user.UserName);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}