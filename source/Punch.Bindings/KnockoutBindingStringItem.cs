using System.Text;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutBindingStringItem : KnockoutBindingItem
    {

        public KnockoutBindingStringItem(string value, bool needQuotes = false)
            : this(null, value, needQuotes) { }

        public KnockoutBindingStringItem(string name, string value, bool needQuotes = false)
        {
            SetCustomName(name);
            Guard.NotNullOrEmpty(() => value, value);
            Value = value;
            NeedQuotes = needQuotes;
        }

        public string Value { get; set; }
        public bool NeedQuotes { get; set; }

        public override string GetKnockoutExpression(KnockoutExpressionData data)
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" : ");
            if (NeedQuotes)
                sb.Append('\'');
            sb.Append(Value);
            if (NeedQuotes)
                sb.Append('\'');

            return sb.ToString();
        }
    }
}
