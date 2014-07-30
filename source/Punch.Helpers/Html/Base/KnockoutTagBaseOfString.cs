using Punch.Bindings;


namespace Punch.Helpers
{
    public abstract class KnockoutTagBaseOfString<TType> : KnockoutTagBase<TType, KnockoutBindingCollection>
        where TType : KnockoutTagBaseOfString<TType>
    {
        #region Properties and Constructors
        private string PropertyName { get; set; }

        protected KnockoutTagBaseOfString(string tagName, string propertyName)
            : base(tagName, new KnockoutBindingCollection())
        {
            this.PropertyName = propertyName;
        }
        #endregion


        protected override string GetPropertyName()
        {
            return this.PropertyName;
        }

    }


}
