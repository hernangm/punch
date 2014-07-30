using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutAttrBinding : KnockoutBindingComplexItem
    {
        public KnockoutAttrBinding() : base() { }
    }

    public static class KnockoutAttrBindingExtensions
    {
        public static TReturn Attr<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string attribute, string binding)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add<KnockoutAttrBinding>(new KnockoutBindingStringItem(attribute, binding));
            return bindings.ReturnObject;
        }

        public static TReturn Attr<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string attribute, string binding, bool needQuotes)
                    where TReturn : IKnockoutBindingCollection
        {
            bindings.Add<KnockoutAttrBinding>(new KnockoutBindingStringItem(attribute, binding, needQuotes));
            return bindings.ReturnObject;
        }

        public static TReturn Attr<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, string attribute, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add<KnockoutAttrBinding>(new KnockoutBindingItem<TModel, object>(attribute, binding));
            return bindings.ReturnObject;
        }
    }
}
