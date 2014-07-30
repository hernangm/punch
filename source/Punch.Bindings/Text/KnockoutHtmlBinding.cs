using System;
using System.Linq.Expressions;
using System.Web;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutHtmlBinding<TModel, TResult> : KnockoutBindingItem<TModel, TResult>
    {
        public KnockoutHtmlBinding(Expression<Func<TModel, TResult>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutHtmlBindingExtensions
    {
        public static TReturn Html<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, IHtmlString>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutHtmlBinding<TModel, IHtmlString>(binding));
            return bindings.ReturnObject;
        }

        public static TReturn Html<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, string>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutHtmlBinding<TModel, string>(binding));
            return bindings.ReturnObject;
        }

        public static TReturn Html<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, Expression<Func<string>>>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutHtmlBinding<TModel, Expression<Func<string>>>(binding));
            return bindings.ReturnObject;
        }
    }
}
