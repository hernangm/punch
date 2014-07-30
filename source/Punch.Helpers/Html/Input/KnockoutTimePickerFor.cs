using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{

    public class KnockoutTimePicker<TModel> : KnockoutTextInputBase<KnockoutTimePicker<TModel>, TModel>
    {
        public KnockoutTimePicker(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Text, binding, instancesNames, aliases)
        {
            //this.AppendedAddOns.Add(new AddOn() { Icon = "icon-clockcalendar" });

        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("size", "5");
            tagBuilder.Attributes.Add("autocomplete", "off");
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.TimePicker(Binding);
        }
    }

    public static class KnockoutTimePickerForExtensions
    {
        public static KnockoutTimePicker<TModel> TimePickerFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutTimePicker<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }


}
