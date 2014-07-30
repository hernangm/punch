using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutIfBinding : KnockoutBindingStringItem
    {
        public KnockoutIfBinding(string binding)
            : base(binding, false)
        { }
    }

    public class KnockoutIfBinding<TModel> : KnockoutBindingItem<TModel, bool>
    {
        public KnockoutIfBinding(Expression<Func<TModel, bool>> binding)
            : base(binding)
        { }
    }

    public static class KnockoutIfBindingExtensions
    {
        public static TReturn If<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutIfBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn If<TReturn, TModel>(this IKnockoutBindingCollection<TReturn,TModel> bindings, Expression<Func<TModel, bool>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutIfBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
