using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;


namespace Punch.Helpers
{
    public class KnockoutTag : KnockoutTagBaseOfString<KnockoutTag>
    {

        public KnockoutTag(string tag, string property)
            : base(tag, property) { }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Text(this.GetBindingName());
        }
    }

    public static class KnockoutTagExtensions
    {
        public static KnockoutTag Tag(this IKnockoutHtmlContext html, string tag, string property)
        {
            return new KnockoutTag(tag, property);
        }

        public static KnockoutTag Span(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutTag("span", property);
        }
    }
}
