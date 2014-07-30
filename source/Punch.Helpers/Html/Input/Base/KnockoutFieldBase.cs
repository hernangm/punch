using System.Web.Mvc;
using Punch.Helpers;

namespace Punch.Helpers
{
    public abstract class KnockoutFieldBase<TType> : KnockoutTagBaseOfString<TType>, IField<TType>
        where TType : KnockoutFieldBase<TType>
    {

        #region Properties
        public FieldType Type { get; private set; }
        public KnockoutLabel Label { get; private set; }
        #endregion

        #region Constructors
        protected KnockoutFieldBase(FieldType type, string propertyName)
            : base(type.ToString().ToLowerInvariant(), propertyName)
        {
            Guard.NotNullOrEmpty(() => propertyName, propertyName);
            this.Type = type;
            this.Label = new KnockoutLabel(this, this.GetPropertyName());
            base.RegisterProcessor(new LabelPostProcessor());
        }
        #endregion

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            tagBuilder.Attributes.Add("id", this.GetId());
        }
    }
}
