using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutOptionsTextBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutOptionsTextBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public class KnockoutOptionsTextBinding : KnockoutBindingStringItem
    {
        public KnockoutOptionsTextBinding(string text, bool needQuotes = false)
            : base(text, needQuotes)
        { }
    }


    public static class KnockoutOptionsTextBindingExtensions
    {
        public static TReturn OptionsText<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string text, bool needQuotes = false)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutOptionsTextBinding(text, needQuotes));
            return bindings.ReturnObject;
        }

        public static TReturn OptionsText<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutOptionsTextBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
