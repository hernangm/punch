using System.Web.Mvc;
using Punch.Contracts;
using Punch.Core;


namespace Punch.Helpers
{
    public class KnockoutTextBox : KnockoutTextInputBase<KnockoutTextBox>
    {
        public KnockoutTextBox(string property)
            : base(InputType.Text, property)
        {
        }
    }

    public static class KnockoutTextBoxExtensions
    {
        public static KnockoutTextBox TextBox(this IKnockoutHtmlContext html, string binding)
        {
            return new KnockoutTextBox(binding);
        }
    }
}
