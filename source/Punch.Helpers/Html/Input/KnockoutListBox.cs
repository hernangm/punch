using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;


namespace Punch.Helpers
{

    public class KnockoutListBox<TModel> : KnockoutSelectBase<KnockoutListBox<TModel>, TModel, IEnumerable> 
    {

        public KnockoutListBox(KnockoutContext<TModel> context, Expression<Func<TModel, IEnumerable>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, binding, instancesNames, aliases)
        {
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.ConfigureBinding(bindings);
            bindings.SelectedOptions(Binding);
        }

        protected override void ConfigureTagBuilder(System.Web.Mvc.TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("multiple", "multiple");
        }

    }
}
