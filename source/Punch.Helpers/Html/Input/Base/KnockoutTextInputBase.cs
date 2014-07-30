using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Punch.Bindings;

namespace Punch.Helpers
{
    public abstract class KnockoutTextInputBase<TType> : KnockoutInputBase<TType>
        // , IInputWithAddOns 
                                                        where TType : KnockoutTextInputBase<TType>
    {
        //public IList<AddOn> PrependedAddOns { get; set; }
        //public IList<AddOn> AppendedAddOns { get; set; }
        protected KnockoutValueUpdateKind _UpdateWhen { get; set; }

        public KnockoutTextInputBase(InputType inputType, string property)
            : base(inputType, property)
        {
            if (inputType == InputType.CheckBox || inputType == InputType.Radio)
            {
                throw new ArgumentException("Input type can only be text, hidden or password.");
            }
            //base.RegisterPostProcessor(new AddOnPostProcessor());
            //this.PrependedAddOns = new List<AddOn>();
            //this.AppendedAddOns = new List<AddOn>();
            this._UpdateWhen = KnockoutValueUpdateKind.Change;

        }

        public TType UpdateWhen(KnockoutValueUpdateKind kind)
        {
            this._UpdateWhen = kind;
            return (TType)this;
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            base.ConfigureBinding(bindings);
            if (this._UpdateWhen != KnockoutValueUpdateKind.Change)
            {
                bindings.ValueUpdate(this._UpdateWhen);
            }
        }

    }
}
