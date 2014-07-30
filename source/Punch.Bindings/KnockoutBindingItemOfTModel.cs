using System;
using System.Linq.Expressions;
using System.Text;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutBindingItem<TModel, TResult> : KnockoutBindingItem
    {
        public Expression<Func<TModel, TResult>> Expression { get; private set; }

        public KnockoutBindingItem(string name, Expression<Func<TModel, TResult>> binding)
        {
            SetCustomName(name);
            Guard.NotNull(() => binding, binding);
            this.Expression = binding;
        }

        protected KnockoutBindingItem(Expression<Func<TModel, TResult>> binding) : this(null, binding) { }

        public override string GetKnockoutExpression(KnockoutExpressionData data)
        {
            string value = GetValue(data);
            var sb = new StringBuilder();

            sb.Append(Name);
            sb.Append(" : ");
            sb.Append(value);

            return sb.ToString();
        }

        protected virtual string GetValue(KnockoutExpressionData data)
        {
            string value = KnockoutExpressionConverter.Convert(Expression, data);
            if (string.IsNullOrWhiteSpace(value))
            {
                value = "$data";
            }
            return value;
        }
    }
}
