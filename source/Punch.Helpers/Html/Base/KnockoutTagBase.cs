using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;
using System.Linq;

namespace Punch.Helpers
{
    public abstract class KnockoutTagBase<TType, TBindingCollection> : IFluentInterface, ITag<TType>, IKnockoutBindingCollection<TType>
        where TType : KnockoutTagBase<TType, TBindingCollection>
        where TBindingCollection : IKnockoutBindingCollection
    {
        #region Properties and Constructors
        private bool tagBuilderConfigured { get; set; }
        private TagBuilder TagBuilder { get; set; }
        protected TagRenderMode TagRenderMode { get; set; }
        public string TagName { get { return this.TagBuilder.TagName; } }

        private bool bindingConfigured { get; set; }
        protected TBindingCollection Bindings { get; private set; }
        protected string CustomBinding { get; set; }

        private string Id { get; set; }

        private List<ITagProcessor> Processors { get; set; }

        public TType ReturnObject { get { return (TType)this; } }

        protected KnockoutTagBase(string tagName, TBindingCollection bindings)
        {
            Guard.NotNullOrEmpty(() => tagName, tagName);
            TagBuilder = new TagBuilder(tagName);
            TagRenderMode = TagRenderMode.Normal;
            this.Bindings = bindings;
            this.Processors = new List<ITagProcessor>();
        }
        #endregion

        #region Fluent Methods
        public TType Attributes(object htmlAttributes)
        {
            this.TagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return (TType)this;
        }

        public TType AddClass(string @class)
        {
            this.AddClass1(@class);
            return (TType)this;
        }

        public TType BindTo(string binding)
        {
            this.CustomBinding = binding;
            return (TType)this;
        }

        public TType WithId(string id)
        {
            Guard.NotNullOrEmpty(() => id, id);
            this.Id = id;
            return (TType)this;
        }

        public string GetId()
        {
            return TagBuilder.CreateSanitizedId(!string.IsNullOrEmpty(Id) ? Id : this.GetPropertyName());
        }
        #endregion

        #region Virtual Methods
        protected abstract string GetPropertyName();

        protected virtual string GetBindingName()
        {
            return GetPropertyName();
        }

        protected virtual void ConfigureTagBuilder(TagBuilder tagBuilder) { }

        protected abstract void ConfigureBinding(TBindingCollection bindings);

        protected virtual void PreConfigureBinding(TBindingCollection bindings)
        {
            if (this.HasCustomBinding)
            {
                bindings.Add(new KnockoutCustomBinding(this.CustomBinding, GetBindingName(), false));
            }
        }
        #endregion

        #region IHtmlString
        public string ToHtmlString()
        {
            foreach (var processor in this.Processors)
            {
                if (processor.CanProcess(this))
                {
                    processor.PreProcess(this);
                }
            }
            var tag = CreateTagBuilder().ToString(this.TagRenderMode);
            foreach (var processor in this.Processors)
            {
                if (processor.CanProcess(this))
                {
                    tag = processor.PostProcess(this, tag);
                }
            }
            return tag;
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
        #endregion

        protected TagBuilder CreateTagBuilder()
        {
            if (!tagBuilderConfigured)
            {
                ConfigureTagBuilder(TagBuilder);
                PreConfigureBinding(this.Bindings);
                if (!this.HasCustomBinding)
                {
                    ConfigureBinding(this.Bindings);
                }
                //ojo aca con el parametro null
                TagBuilder.Attributes["data-bind"] = this.Bindings.GetBindingAttribute(null);
            }
            tagBuilderConfigured = true;
            return TagBuilder;
        }

        public void RegisterProcessor(ITagProcessor postProcessor)
        {
            this.Processors.Add(postProcessor);
        }

        protected bool HasCustomBinding { get { return !string.IsNullOrEmpty(this.CustomBinding); } }

        public void Add(IKnockoutBindingItem binding)
        {
            this.Bindings.Add(binding);
        }

        public void Add<TComplex>(IKnockoutBindingItem binding) where TComplex : IKnockoutBindingComplexItem
        {
            this.Bindings.Add<TComplex>(binding);
        }

        public string GetBindingAttribute(KnockoutExpressionData data)
        {
            return this.Bindings.GetBindingAttribute(data);
        }


        public bool ContainsProcessor<TProcessor>() where TProcessor : ITagProcessor
        {
            return this.Processors.Any(m => m.GetType() == typeof(TProcessor));
        }

        public TProcessor GetProcessor<TProcessor>() where TProcessor : ITagProcessor
        {
            return (TProcessor)this.Processors.First(m => m.GetType() == typeof(TProcessor));
        }


        public void AddClass1(string @class)
        {
            this.TagBuilder.AddCssClass(@class);
        }
    }

}
