using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{

    public abstract class KnockoutTextInputBase<TType, TModel> : KnockoutInputBase<TType, TModel> where TType : KnockoutTextInputBase<TType, TModel>
    {

        protected KnockoutValueUpdateKind _UpdateWhen { get; set; }

        public KnockoutTextInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, inputType, binding, instancesNames, aliases)
        {
            if (inputType == InputType.CheckBox || inputType == InputType.Radio)
            {
                throw new ArgumentException("Input type can only be text, hidden or password.");
            }
            this._UpdateWhen = KnockoutValueUpdateKind.Change;
        }

        public TType UpdateWhen(KnockoutValueUpdateKind kind)
        {
            this._UpdateWhen = kind;
            return (TType)this;
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            if (this._UpdateWhen != KnockoutValueUpdateKind.Change)
            {
                bindings.ValueUpdate(this._UpdateWhen);
            }
        }
    }
}
