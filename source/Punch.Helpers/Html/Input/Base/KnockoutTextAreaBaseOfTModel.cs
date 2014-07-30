using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{
    public abstract class KnockoutTextAreaBase<TType, TModel> : KnockoutFieldBase<TType, TModel, object>
        where TType : KnockoutTextAreaBase<TType, TModel>
        
    {
        #region Constructors
        public KnockoutTextAreaBase(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.TextArea, binding, instancesNames, aliases)
        {
        }
        #endregion

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Value(Binding);
        }
    }
}
