using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutTimePickerBinding : KnockoutBindingStringItem
    {
        public KnockoutTimePickerBinding(string property) : base(property) { }
    }

    public class KnockoutTimePickerBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutTimePickerBinding(Expression<Func<TModel, object>> binding) : base(binding) { }
    }

    public static class KnockoutTimePickerBindingExtensions
    {
        public static TReturn TimePicker<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutTimePickerBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn TimePicker<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutTimePickerBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
