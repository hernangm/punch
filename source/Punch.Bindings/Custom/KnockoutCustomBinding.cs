using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{

    public class KnockoutCustomBinding<TModel, TProperty> : KnockoutBindingItem<TModel, TProperty>
    {
        public KnockoutCustomBinding(string binding, Expression<Func<TModel, TProperty>> property)
            : base(binding, property)
        { }
    }


    public class KnockoutCustomBinding : KnockoutBindingStringItem
    {
        public KnockoutCustomBinding(string binding, string property)
            : base(binding, property)
        { }

        public KnockoutCustomBinding(string binding, string property, bool needQuotes)
            : base(binding, property, needQuotes)
        { }
    }

    public static class KnockoutCustomBindingExtensions
    {
        public static TReturn Custom<TReturn, TModel, TProperty>(this IKnockoutBindingCollection<TReturn, TModel> bindings, string binding, Expression<Func<TModel, TProperty>> property)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutCustomBinding<TModel, TProperty>(binding, property));
            return bindings.ReturnObject;
        }

        public static TReturn Custom<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string binding, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutCustomBinding(binding, property));
            return bindings.ReturnObject;
        }

        public static TReturn Custom<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string binding, string property, bool needQuotes = false)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutCustomBinding(binding, property, needQuotes));
            return bindings.ReturnObject;
        }
    }

}
