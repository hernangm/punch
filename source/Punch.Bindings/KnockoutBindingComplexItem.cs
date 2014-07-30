using System.Collections.Generic;
using System.Text;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutBindingComplexItem : KnockoutBindingItem, IKnockoutBindingComplexItem
    {
        private readonly List<IKnockoutBindingItem> subItems = new List<IKnockoutBindingItem>();

        public KnockoutBindingComplexItem()
            : base() { }

        public KnockoutBindingComplexItem(string name)
        {
            SetCustomName(name);
        }


        public void Add(IKnockoutBindingItem subItem)
        {
            subItems.Add(subItem);
        }

        public override bool IsValid()
        {
            return subItems.Count > 0;
        }

        public override string GetKnockoutExpression(KnockoutExpressionData data)
        {
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" : {");
            for (int i = 0; i < subItems.Count; i++)
            {
                if (i != 0)
                    sb.Append(",");
                sb.Append(subItems[i].GetKnockoutExpression(data));
            }
            sb.Append('}');

            return sb.ToString();
        }
    }
}