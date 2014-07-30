using System;
using System.Linq.Expressions;

namespace Punch.Bindings
{
    public class KnockoutTooltipBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutTooltipBinding(Expression<Func<TModel, object>> binding) : base(binding) { }
    }
}
