using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public class KnockoutTextArea : KnockoutTextAreaBase<KnockoutTextArea>
    {
        #region Constructors
        public KnockoutTextArea(string property)
            : base(property)
        {
        }
        #endregion
    }

    public static class KnockoutTextAreaExtensions
    {
        public static KnockoutTextArea TextArea(this IKnockoutHtmlContext html, string property)
        {
            return new KnockoutTextArea(property);
        }
    }
}
