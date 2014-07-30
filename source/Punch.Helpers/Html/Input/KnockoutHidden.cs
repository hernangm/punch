using System.Web.Mvc;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutHidden : KnockoutTextInputBase<KnockoutHidden>
    {
        public KnockoutHidden(string property)
            : base(InputType.Hidden, property)
        {
        }
    }

    public static class KnockoutHiddenExtensions
    {
        public static KnockoutHidden Hidden(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutHidden(property);
        }
    }
}
