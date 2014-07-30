using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutOptionsCaptionBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutOptionsCaptionBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }

    public class KnockoutOptionsCaptionBinding : KnockoutBindingStringItem
    {
        public KnockoutOptionsCaptionBinding(string text, bool needQuotes = false)
            : base(text, needQuotes)
        { }
    }

    public static class KnockoutOptionsCaptionBindingExtensions
    {
        public static TReturn OptionsCaption<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string caption, bool needQuotes = false)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutOptionsCaptionBinding(caption, needQuotes));
            return bindings.ReturnObject;
        }

        public static TReturn OptionsCaption<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutOptionsCaptionBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
