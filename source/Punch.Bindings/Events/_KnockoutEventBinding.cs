using System;
using System.Linq.Expressions;

namespace Punch.Bindings
{
    public abstract class KnockoutEventBinding<TModel> : KnockoutBindingItem<TModel, Action>
    {
        protected KnockoutEventBinding(Expression<Func<TModel, Action>> binding)
            : base(binding)
        { }
    }
}
