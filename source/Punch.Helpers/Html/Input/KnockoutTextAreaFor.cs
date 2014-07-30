using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutTextArea<TModel> : KnockoutTextAreaBase<KnockoutTextArea<TModel>, TModel> 
    {
        #region Constructors
        public KnockoutTextArea(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }
        #endregion
    }

    public static class KnockoutTextAreaForExtensions
    {
        public static KnockoutTextArea<TModel> TextAreaFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutTextArea<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}
