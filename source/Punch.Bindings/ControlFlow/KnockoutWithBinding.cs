using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutWithBinding : KnockoutBindingStringItem
    {
        public KnockoutWithBinding(string binding)
            : base(binding, false)
        { }
    }

    public class KnockoutWithBinding<TModel, TProperty> : KnockoutBindingItem<TModel, TProperty>
    {
        public KnockoutWithBinding(Expression<Func<TModel, TProperty>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutWithBindingExtensions
    {
        public static TReturn With<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutWithBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn With<TReturn, TModel, TProperty>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, TProperty>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutWithBinding<TModel, TProperty>(binding));
            return bindings.ReturnObject;
        }
    }
}
