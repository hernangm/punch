using System;
using System.Web.Mvc;
using Punch.Bindings;


namespace Punch.Helpers
{

    public abstract class KnockoutCheckedInputBase<TType> : KnockoutInputBase<TType> 
        where TType : KnockoutCheckedInputBase<TType>
    {

        public KnockoutCheckedInputBase(InputType inputType, string property)
            : base(inputType, property)
        {
            if (!(inputType == InputType.CheckBox || inputType == InputType.Radio))
            {
                throw new ArgumentException("Input type can only be checkable.");
            }
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Checked(this.GetBindingName());
        }


    }
}
