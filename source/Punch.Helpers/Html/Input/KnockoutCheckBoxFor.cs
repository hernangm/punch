using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutCheckBox<TModel> : KnockoutCheckedInputBase<KnockoutCheckBox<TModel>, TModel> 
    {
        public KnockoutCheckBox(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.CheckBox, binding, instancesNames, aliases)
        {
        }
    }

    public static class KnockoutCheckBoxForExtensions
    {
        public static KnockoutCheckBox<TModel> CheckBoxFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutCheckBox<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}