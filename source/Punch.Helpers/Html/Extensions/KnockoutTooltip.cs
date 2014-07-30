using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutTooltip<TModel, TItem> : KnockoutTagBaseOfTModel<KnockoutTooltip<TModel, TItem>, TModel, TItem> 
    {
        public KnockoutTooltip(KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("div", context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            var propertyName = GetBindingName() + "." + "tooltip";
            bindings.Tooltip(propertyName);
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            this.AddClass("tooltip");
        }

    }

    public static class TooltipKnockoutTagBuilderExtensions
    {
        public static TReturn Tooltip<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutBindingStringItem("tooltip", property, false));
            return bindings.ReturnObject;
        }
    }
}
