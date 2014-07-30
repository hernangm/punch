using Punch.Bindings;

namespace Punch.Helpers
{
    public abstract class KnockoutSelectBase<TType> : KnockoutFieldBase<TType> where TType : KnockoutSelectBase<TType>
    {
        protected string Options { get; set; }
        protected string OptionsCaption { get; set; }
        protected string OptionsText { get; set; }
        protected string OptionsValue { get; set; }

        public KnockoutSelectBase(string propertyName, string options)
            : base(FieldType.Select, propertyName)
        {
            Guard.NotNullOrEmpty(() => options, options);
            this.Options = options;
        }

        public TType WithCaption(string caption)
        {
            this.OptionsCaption = caption;
            return (TType)this;
        }

        public TType WithOptionText(string optionText)
        {
            this.OptionsText = optionText;
            return (TType)this;
        }

        public TType WithOptionValue(string optionValue)
        {
            this.OptionsValue = optionValue;
            return (TType)this;
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Options(this.Options);
            if (!string.IsNullOrEmpty(OptionsCaption))
            {
                bindings.OptionsCaption(this.OptionsCaption);
            }
            if (!string.IsNullOrEmpty(OptionsValue))
            {
                bindings.OptionsValue(this.OptionsValue);
            }
            if (!string.IsNullOrEmpty(OptionsText))
            {
                bindings.OptionsText(this.OptionsText);
            }
        }
    }
}
