using System.Web.Mvc;
using Punch.Contracts;
using Punch.Core;


namespace Punch.Helpers
{
    public class KnockoutRadioButton : KnockoutCheckedInputBase<KnockoutRadioButton>
    {
        public KnockoutRadioButton(string property)
            : base(InputType.Radio, property)
        {
        }
    }

    public static class KnockoutRadioButtonExtensions
    {
        public static KnockoutRadioButton RadioButton(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutRadioButton(property);
        }
    }
}