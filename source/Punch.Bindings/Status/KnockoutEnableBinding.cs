using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutEnableBinding : KnockoutBindingStringItem
    {
        public KnockoutEnableBinding(string binding)
            : base(binding, false)
        { }
    }

    public class KnockoutEnableBinding<TModel> : KnockoutBindingItem<TModel, bool>
    {
        public KnockoutEnableBinding(Expression<Func<TModel, bool>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutEnableBindingExtensions
    {
        public static TReturn Enable<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutEnableBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn Enable<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, bool>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutEnableBinding<TModel>(binding));
            return bindings.ReturnObject;
        }

    }
}
