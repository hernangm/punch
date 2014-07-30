using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutNumericBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutNumericBinding(Expression<Func<TModel, object>> binding) : base(binding) { }
    }

    public class KnockoutNumericBinding : KnockoutBindingStringItem
    {
        public KnockoutNumericBinding(string property) : base(property) { }
    }

    public static class KnockoutNumericBindingExtensions
    {
        public static TReturn Numeric<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutNumericBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn Numeric<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutNumericBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
