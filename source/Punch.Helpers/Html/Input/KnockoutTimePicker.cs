using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{

    public class KnockoutTimePicker : KnockoutTextInputBase<KnockoutTimePicker>
    {
        public KnockoutTimePicker(string property)
            : base(InputType.Text, property)
        {
            //this.AppendedAddOns.Add(new AddOn() { Icon = "icon-clockcalendar" });

        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("size", "5");
            tagBuilder.Attributes.Add("autocomplete", "off");
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.TimePicker(this.GetBindingName());
        }
    }

    public static class KnockoutTimePickerExtensions
    {
        public static KnockoutTimePicker TimePicker(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutTimePicker(property);
        }
    }


}
