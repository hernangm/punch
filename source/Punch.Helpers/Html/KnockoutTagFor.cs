using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutTag<TModel> : KnockoutTagBaseOfTModel<KnockoutTag<TModel>, TModel, object>
    {
        public KnockoutTag(string tag, KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(tag, context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Text(Binding);
        }

        protected override IEnumerable<IKnockoutBindingMetadata> GetBindingMetadata()
        {
            return base.GetBindingMetadata().Where(m=> m.GetType().GetInterfaces().Any(i => i == typeof(IKnockoutInputBindingMetadata)));
        }
    }

    public static class KnockoutTagForExtensions
    {
        public static KnockoutTag<TModel> TagFor<TModel>(this KnockoutHtmlContext<TModel> html, string tag, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutTag<TModel>(tag, html.Context, binding, data.InstanceNames, data.Aliases);
        }

        public static KnockoutTag<TModel> SpanFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutTag<TModel>("span", html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}
