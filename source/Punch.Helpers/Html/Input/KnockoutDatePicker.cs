using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutDatePicker : KnockoutTextInputBase<KnockoutDatePicker>
    {
        public KnockoutDatePicker(string property)
            : base(InputType.Text, property)
        {
            //this.AppendedAddOns.Add(new AddOn() { Icon = "icon-calendar" });
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("size", "10");
            tagBuilder.Attributes.Add("autocomplete", "off");
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.DatePicker(this.GetBindingName());
        }
    }

    public static class KnockoutDatePickerExtensions
    {
        public static KnockoutDatePicker DatePicker(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutDatePicker(property);
        }
    }

}