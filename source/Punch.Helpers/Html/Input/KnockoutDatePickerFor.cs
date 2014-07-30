using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutDatePicker<TModel> : KnockoutTextInputBase<KnockoutDatePicker<TModel>, TModel> 
    {
        public KnockoutDatePicker(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Text, binding, instancesNames, aliases)
        {
            //this.AppendedAddOns.Add(new AddOn() { Icon = "icon-calendar" });
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("size", "10");
            tagBuilder.Attributes.Add("autocomplete", "off");
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.DatePicker(Binding);
        }
    }

    public static class KnockoutDatePickerForExtensions
    {
        public static KnockoutDatePicker<TModel> DatePickerFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutDatePicker<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }

}