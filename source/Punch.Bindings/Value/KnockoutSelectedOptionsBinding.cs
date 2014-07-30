using System;
using System.Collections;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutSelectedOptionsBinding<TModel> : KnockoutBindingItem<TModel, IEnumerable>
    {
        public KnockoutSelectedOptionsBinding(Expression<Func<TModel, IEnumerable>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutSelectedOptionsBindingExtensions
    {
        public static TReturn SelectedOptions<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, IEnumerable>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutSelectedOptionsBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
