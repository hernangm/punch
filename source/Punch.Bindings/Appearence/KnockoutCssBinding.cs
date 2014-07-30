using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutCssBinding : KnockoutBindingComplexItem
    {
        public KnockoutCssBinding()
            : base() { }
    }

    public static class KnockoutCssBindingExtensions
    {
        public static TReturn Css<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, string attribute, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add<KnockoutCssBinding>(new KnockoutBindingItem<TModel, object>(attribute, binding));
            return bindings.ReturnObject;
        }
    }
}
