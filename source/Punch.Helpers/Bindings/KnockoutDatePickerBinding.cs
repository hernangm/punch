using System;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutDatePickerBinding : KnockoutBindingStringItem
    {
        public KnockoutDatePickerBinding(string property) : base(property) { }
    }

    public class KnockoutDatePickerBinding<TModel> : KnockoutBindingItem<TModel, object>
    {
        public KnockoutDatePickerBinding(Expression<Func<TModel, object>> binding) : base(binding) { }
    }

    public static class KnockoutDatePickerBindingExtensions
    {
        public static TReturn DatePicker<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutDatePickerBinding(property));
            return bindings.ReturnObject;
        }

        public static TReturn DatePicker<TReturn, TModel>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, object>> binding)
            where TReturn : IKnockoutBindingCollection
            
        {
            bindings.Add(new KnockoutDatePickerBinding<TModel>(binding));
            return bindings.ReturnObject;
        }
    }
}
