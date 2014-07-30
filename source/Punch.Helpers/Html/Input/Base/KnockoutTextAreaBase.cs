using Punch.Bindings;

namespace Punch.Helpers
{
    public abstract class KnockoutTextAreaBase<TType> : KnockoutFieldBase<TType> where TType : KnockoutTextAreaBase<TType>
    {
        #region Constructors
        public KnockoutTextAreaBase(string property)
            : base(FieldType.TextArea, property)
        {
        }
        #endregion

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
            bindings.Value(this.GetBindingName());
        }
    }
}
