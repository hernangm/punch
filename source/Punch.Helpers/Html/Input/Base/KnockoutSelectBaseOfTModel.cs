using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public abstract class KnockoutSelectBase<TType, TModel, TItem> : KnockoutFieldBase<TType, TModel, TItem> 
        where TType : KnockoutSelectBase<TType, TModel, TItem>
        
    {
        protected Expression<Func<TModel, IEnumerable<TItem>>> SelectOptions { get; set; }
        protected Expression<Func<object, object>> SelectOptionsText { get; set; }

        public KnockoutSelectBase(KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.Select, binding, instancesNames, aliases)
        {
        }


        public TType WithOptions(Expression<Func<TModel, IEnumerable<TItem>>> options)
        {
            this.SelectOptions = options;
            return (TType)this;
        }


        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            if (SelectOptions != null)
            {
                bindings.Options(Expression.Lambda<Func<TModel, IEnumerable>>(SelectOptions.Body, SelectOptions.Parameters));
            }
            if (SelectOptionsText != null)
            {
                var data = new KnockoutExpressionData { InstanceNames = new[] { "item" } };
                bindings.OptionsText("function(item) { return " + KnockoutExpressionConverter.Convert(SelectOptions, data) + "; }");
            }
        }
    }
}
