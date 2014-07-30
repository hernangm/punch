using System;
using System.Collections;
using System.Linq.Expressions;
using Punch.Context;

namespace Punch.Helpers
{
    public static class KnockoutHtmlExtensions
    {

        #region ValidationSummary
        public static KnockoutValidationSummary ValidationSummary<TModel>(this KnockoutHtmlContext<TModel> html)
            
        {
            return new KnockoutValidationSummary();
        }
        #endregion

        #region ListBoxFor
        public static KnockoutListBox<TModel> ListBoxFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, IEnumerable>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutListBox<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
        #endregion

    }
}
