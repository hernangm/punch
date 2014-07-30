using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutAnchor<TModel> : KnockoutTagBaseOfTModel<KnockoutAnchor<TModel>, TModel, Action> 
    {
        private string Label { get; set; }

        public KnockoutAnchor(KnockoutContext<TModel> context, Expression<Func<TModel, Action>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("a", context, binding, instancesNames, aliases)
        {
        }

        public KnockoutAnchor<TModel> WithLabel(string label)
        {
            this.Label = label;
            return this;
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Click(Binding);
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            tagBuilder.Attributes.Add("href", "#");
            tagBuilder.InnerHtml = Label;
        }
    }

    public static class KnockoutAnchorExtensions
    {
        public static KnockoutAnchor<TModel> LinkButton<TModel>(this KnockoutHtmlContext<TModel> html, string label, Expression<Func<TModel, Action>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutAnchor<TModel>(html.Context, binding, data.InstanceNames, data.Aliases).WithLabel(label);
        }
    }
}
