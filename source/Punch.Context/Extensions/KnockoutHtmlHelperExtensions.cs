using System.Web.Mvc;

namespace Punch.Context
{
    public static class KnockoutHtmlHelperExtensions
    {
        public static KnockoutContext<TModel> Knockout<TModel>(this HtmlHelper<TModel> html) 
        {
            return new KnockoutContext<TModel>(html.ViewContext);
        }
    }

}
