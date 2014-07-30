using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutVisibleBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutVisibleBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutVisibleBindingExtensions
    {
        public static TReturn Visible<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutVisibleBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
