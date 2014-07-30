using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{

    public class KnockoutNumericBox<TModel> : KnockoutTextBox<TModel> 
    {
        public KnockoutNumericBox(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Numeric(Binding);
        }
    }

    public static class KnockoutNumericBoxForExtensions
    {
        public static KnockoutNumericBox<TModel> NumericBoxFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutNumericBox<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }

}
