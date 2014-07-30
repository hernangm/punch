using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutDropDownList<TModel> : KnockoutSelectBase<KnockoutDropDownList<TModel>, TModel, object> 
    {
        public KnockoutDropDownList(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.Value(Binding);
        }
    }

    public static class KnockoutDropDownListExtensions
    {
        public static KnockoutDropDownList<TModel> DropDownListFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutDropDownList<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}
