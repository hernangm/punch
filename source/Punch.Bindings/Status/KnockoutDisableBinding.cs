using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutDisableBinding<TModel> : KnockoutBindingItem<TModel, bool>
    {
        public KnockoutDisableBinding(Expression<Func<TModel, bool>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutDisableBindingExtensions
    {
        public static TReturn Disable<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, bool>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutDisableBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
