using System;
using System.Collections;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutOptionsBinding<TModel> : KnockoutBindingItem<TModel, IEnumerable>
    {
        public KnockoutOptionsBinding(Expression<Func<TModel, IEnumerable>> binding)
            : base(binding)
        { }
    }

    public class KnockoutOptionsBinding : KnockoutBindingStringItem
    {
        public KnockoutOptionsBinding(string options)
            : base(options, false)
        { }
    }

    public static class KnockoutOptionsBindingExtensions
    {
        public static TReturn Options<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string options)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutOptionsBinding(options));
            return bindings.ReturnObject;
        }

        public static TReturn Options<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, IEnumerable>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutOptionsBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
