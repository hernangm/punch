using System.Web.Mvc;
using Punch.Bindings;

namespace Punch.Helpers
{
    public abstract class KnockoutInputBase<TType> : KnockoutFieldBase<TType>, IInput 
        where TType : KnockoutInputBase<TType>
    {
        public InputType InputType { get; private set; }

        public KnockoutInputBase(InputType inputType, string propertyName)
            : base(FieldType.Input, propertyName)
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

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Value(this.GetBindingName());
        }

    }
}
