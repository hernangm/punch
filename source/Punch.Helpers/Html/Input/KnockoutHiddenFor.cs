using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutHidden<TModel> : KnockoutTextInputBase<KnockoutHidden<TModel>, TModel> 
    {
        public KnockoutHidden(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Hidden, binding, instancesNames, aliases)
        {
        }
    }

    public static class KnockoutHiddenForExtensions
    {
        public static KnockoutHidden<TModel> HiddenFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutHidden<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}
