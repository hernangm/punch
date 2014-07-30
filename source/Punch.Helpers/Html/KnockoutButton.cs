using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutButton : KnockoutTagBaseOfString<KnockoutButton>
    {
        public enum ButtonType
        {
            Button,
            Submit,
            Reset
        }
        public ButtonType Type { get; private set; }

        public KnockoutButton(string label, ButtonType type = ButtonType.Button)
            : base("button", label)
        {
            this.Type = type;
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("type", this.Type.ToString().ToLowerInvariant());
            tagBuilder.InnerHtml += GetPropertyName();

        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
        }
    }

    public static class KnockoutButtonExtensions
    {
        public static KnockoutButton Button(this IKnockoutHtmlContext html, string label)
        {
            return new KnockoutButton(label);
        }

        public static KnockoutButton Button(this IKnockoutHtmlContext html, string label, KnockoutButton.ButtonType type)
        {
            return new KnockoutButton(label, type);
        }
    }
}
