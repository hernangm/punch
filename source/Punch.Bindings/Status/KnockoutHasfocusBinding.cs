using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutHasfocusBinding<TModel> : KnockoutBindingItem<TModel, bool>
    {
        public KnockoutHasfocusBinding(Expression<Func<TModel, bool>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutHasfocusBindingExtensions
    {
        public static TReturn HasFocus<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, bool>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutHasfocusBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
