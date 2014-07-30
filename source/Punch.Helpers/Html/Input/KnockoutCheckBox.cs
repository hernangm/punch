using System.Web.Mvc;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutCheckBox : KnockoutCheckedInputBase<KnockoutCheckBox>
    {
        public KnockoutCheckBox(string property)
            : base(InputType.CheckBox, property)
        {
        }
    }

    public static class KnockoutCheckboxExtensions
    {
        public static KnockoutCheckBox CheckBox(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutCheckBox(property);
        }
    }
}