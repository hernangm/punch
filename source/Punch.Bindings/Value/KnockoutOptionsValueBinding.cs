using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutOptionsValueBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutOptionsValueBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public class KnockoutOptionsValueBinding : KnockoutBindingStringItem
    {
        public KnockoutOptionsValueBinding(string text, bool needQuotes = false)
            : base(text, needQuotes)
        { }
    }


    public static class KnockoutOptionValueBindingExtensions
    {
        public static TReturn OptionsValue<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string text, bool needQuotes = false)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutOptionsValueBinding(text, needQuotes));
            return bindings.ReturnObject;
        }

        public static TReturn OptionsValue<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutOptionsValueBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
