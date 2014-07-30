using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;


namespace Punch.Helpers
{

    public abstract class KnockoutCheckedInputBase<TType, TModel> : KnockoutInputBase<TType, TModel> 
        where TType : KnockoutCheckedInputBase<TType, TModel>
        
    {

        public KnockoutCheckedInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, inputType, binding, instancesNames, aliases)
        {
            if (!(inputType == InputType.CheckBox || inputType == InputType.Radio))
            {
                throw new ArgumentException("Input type can only be checkable.");
            }
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Checked(Binding);
        }


    }
}
