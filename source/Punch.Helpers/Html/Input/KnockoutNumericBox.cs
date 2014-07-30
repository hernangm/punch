using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{

    public class KnockoutNumericBox : KnockoutTextBox
    {
        public KnockoutNumericBox(string property)
            : base(property)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Numeric(this.GetBindingName());
        }
    }

    public static class KnockoutNumericBoxExtensions
    {
        public static KnockoutNumericBox NumericBoxFor(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutNumericBox(property);
        }
    }

}
