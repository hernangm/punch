using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutCheckedBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutCheckedBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public class KnockoutCheckedBinding : KnockoutBindingStringItem
    {
        public KnockoutCheckedBinding(string property)
            : base(property, false)
        { }
    }

    public static class KnockoutCheckedBindingExtensions
    {
        public static TReturn Checked<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutCheckedBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn Checked<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutCheckedBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
