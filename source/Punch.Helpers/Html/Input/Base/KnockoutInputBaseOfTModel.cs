using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Context;

namespace Punch.Helpers
{

    public abstract class KnockoutInputBase<TType, TModel> : KnockoutFieldBase<TType, TModel, object>, IInput
        where TType : KnockoutInputBase<TType, TModel>
    {

        public InputType InputType { get; private set; }

        public KnockoutInputBase(KnockoutContext<TModel> context, InputType inputType, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, FieldType.Input, binding, instancesNames, aliases)
        {
            this.InputType = inputType;
            this.TagRenderMode = System.Web.Mvc.TagRenderMode.SelfClosing;
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            tagBuilder.Attributes.Add("type", this.InputType.ToString().ToLowerInvariant());
            tagBuilder.Attributes.Add("name", this.GetPropertyName());
        }

        protected override void ConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            bindings.Value(Binding);
        }

    }
}
