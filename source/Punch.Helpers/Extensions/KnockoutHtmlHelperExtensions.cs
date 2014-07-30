using System.Web.Mvc;
using Punch.Context;

namespace Punch.Helpers
{
    public static class KnockoutHtmlHelperExtensions
    {
        public static KnockoutContext<TModel> Knockout<TModel>(this HtmlHelper<TModel> html) 
        {
            return new KnockoutContext<TModel>(html.ViewContext);
        }
    }

}
