using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutButton<TModel> : KnockoutTagBaseOfTModel<KnockoutButton<TModel>, TModel, Action> 
    {
        public string Label { get; set; }
        public KnockoutButton.ButtonType Type { get; private set; }

        public KnockoutButton(KnockoutContext<TModel> context, string label, Expression<Func<TModel, Action>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base("button", context, binding, instancesNames, aliases)
        {
            this.Label = label;
            this.Type = KnockoutButton.ButtonType.Button;
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Click(Binding);
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            tagBuilder.Attributes.Add("type", this.Type.ToString().ToLowerInvariant());
            tagBuilder.InnerHtml += this.Label;
        }
    }


    public static class KnockoutButtonForExtensions
    {
        public static KnockoutButton<TModel> Button<TModel>(this KnockoutHtmlContext<TModel> html, string label, Expression<Func<TModel, Action>> binding)
            
        {
            return new KnockoutButton<TModel>(html.Context, label, binding, html.InstanceNames, html.Aliases);
        }
    }
}
