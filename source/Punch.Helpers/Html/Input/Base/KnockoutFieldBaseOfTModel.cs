using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;
using System.Linq;
using Punch.Core;

namespace Punch.Helpers
{

    public abstract class KnockoutFieldBase<TType, TModel, TItem> : KnockoutTagBaseOfTModel<TType, TModel, TItem>, IField<TType>
        where TType : KnockoutFieldBase<TType, TModel, TItem>
    {

        #region Properties
        public FieldType Type { get; private set; }
        public KnockoutLabel Label { get; private set; }
        protected bool IsValidatable { get; set; }
        protected bool ShowValidationMessage { get; set; }
        protected bool IsReadOnly { get; set; }
        private string Id { get; set; }
        #endregion

        #region Constructors
        public KnockoutFieldBase(KnockoutContext<TModel> context, FieldType type, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(type.ToString().ToLowerInvariant(), context, binding, instancesNames, aliases)
        {
            this.Label = new KnockoutLabel(this, GetLabel());
            base.RegisterProcessor(new LabelPostProcessor());
        }
        #endregion


        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            tagBuilder.Attributes.Add("id", this.GetId());
        }

        private string GetLabel()
        {
            string label = string.Empty;
            var metadata = this.Context.MetadataProvider.GetMetadataForProperty(null, typeof(TModel), this.GetPropertyName());
            if (metadata != null)
            {
                label = (string)metadata.GetDisplayName();
            }
            //if (this.Context.MetadataProvider.Contains<TModel, TItem, ILabelMetadata>(this.Binding))
            //{
            //    var md = this.Context.MetadataProvider.FirstOrDefault<TModel, TItem, ILabelMetadata>(this.Binding);
            //    label = (string)this.Context.ViewContext.HttpContext.GetGlobalResourceObject(md.ClassKey, md.ResourceKey);
            //}
            if (string.IsNullOrEmpty(label))
            {
                label = this.GetPropertyName();
            }
            return label;
        }
    }
}
