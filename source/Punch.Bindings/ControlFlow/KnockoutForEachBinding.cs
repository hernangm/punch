using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutForEachBinding : KnockoutBindingStringItem
    {
        public KnockoutForEachBinding(string binding)
            : base(binding, false)
        {
            this.SetCasePolicy(NameCaseTypes.LowerCase);
        }
    }

    public class KnockoutForEachBinding<TModel, TItem> : KnockoutBindingItem<TModel, IList<TItem>>
    {
        public KnockoutForEachBinding(Expression<Func<TModel, IList<TItem>>> binding)
            : base(binding)
        {
            this.SetCasePolicy(NameCaseTypes.LowerCase);
        }
    }

    public static class KnockoutForEachBindingExtensions
    {
        public static TReturn ForEach<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutForEachBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn ForEach<TReturn, TModel, TItem>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, IList<TItem>>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutForEachBinding<TModel, TItem>(binding));
            return bindings.ReturnObject;
        }
    }
}
