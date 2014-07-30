using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutTextBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutTextBinding(Expression<Func<TModel, object>> binding)
            : base(binding)
        { }
    }


    public class KnockoutTextBinding : KnockoutBindingStringItem
    {
        public KnockoutTextBinding(string binding)
            : base(binding, false)
        { }
    }

    public static class KnockoutTextBindingExtensions
    {
        public static TReturn Text<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutTextBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn Text<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            var htmlType = typeof(IHtmlString);
            if (binding.Body.Type == htmlType || binding.Body.Type.GetInterfaces().Any(i => i == htmlType))
            {
                var resultBody = Expression.Convert(binding.Body, typeof(IHtmlString));
                var result = Expression.Lambda<Func<TModel, IHtmlString>>(resultBody, binding.Parameters);
                bindings.Html(result);
            }
            else
            {
                bindings.Add(new KnockoutTextBinding<TModel>(binding));
            }

            return bindings.ReturnObject;
        }
    }
}
