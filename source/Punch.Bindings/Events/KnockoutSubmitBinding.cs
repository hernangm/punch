using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutSubmitBinding<TModel> : KnockoutEventBinding<TModel>
    {
        public KnockoutSubmitBinding(Expression<Func<TModel, Action>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutSubmitBindingExtensions
    {
        public static TReturn Submit<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, Action>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutSubmitBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }

}
