using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutClickBinding<TModel> : KnockoutEventBinding<TModel>
    {
        public KnockoutClickBinding(Expression<Func<TModel, Action>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutClickBindingExtensions
    {
        public static TReturn Click<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, Action>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutClickBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
