using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutValueBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutValueBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public class KnockoutValueBinding : KnockoutBindingStringItem
    {
        public KnockoutValueBinding(string property)
            : base(property)
        { }
    }

    public static class KnockoutValueBindingExtensions
    {
        public static TReturn Value<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutValueBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn Value<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutValueBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }

}
