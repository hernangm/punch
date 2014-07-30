using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutStyleBinding : KnockoutBindingComplexItem
    {
        public KnockoutStyleBinding() { }
    }

    public static class KnockoutStyleBindingExtensions
    {
        public static TReturn Style<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, string attribute, Expression<Func<TModel, object>> binding) 
            where TReturn : IKnockoutBindingCollection 
            
        {
            bindings.Add<KnockoutStyleBinding>(new KnockoutBindingItem<TModel, object>(attribute, binding));
            return bindings.ReturnObject;
        }
    }
}