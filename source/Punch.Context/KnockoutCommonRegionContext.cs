using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;

namespace Punch.Context
{
    public abstract class KnockoutCommonRegionContext<TModel, TParent, TChild> : KnockoutRegionContext<TModel>
    {
        protected Expression<Func<TParent, TChild>> Expression { get; private set; }
        protected TagBuilder TagBuilder { get; private set; }
        protected bool IsUsingTag { get { return this.TagBuilder != null; } }
        protected bool WriteTag { get; private set; }

        public KnockoutCommonRegionContext(ViewContext viewContext, Expression<Func<TParent, TChild>> expression, string tag, bool writeTag = true)
            : base(viewContext)
        {
            Expression = expression;
            this.WriteTag = writeTag;
            if (!string.IsNullOrEmpty(tag))
            {
                this.TagBuilder = new TagBuilder(tag);
            }
        }

        public KnockoutCommonRegionContext(ViewContext viewContext, Expression<Func<TParent, TChild>> expression)
            : this(viewContext, expression, null) { }


        public void AddAttributes(object htmlAttributes)
        {
            if (this.IsUsingTag)
            {
                this.TagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }
        }

        protected string GetDataBind()
        {
            if (!this.MetadataProvider.ContainsBindingMetadata(this.Expression))
            {
                return GetBinding().GetKnockoutExpression(this.CreateData());
            }
            var result = new KnockoutBindingCollection();
            var bindings = this.MetadataProvider.WhereBindingMetadata(this.Expression);
            if (!bindings.Any(m => m.ShouldReplace))
            {
                result.Add(GetBinding());
            }
            foreach (var b in bindings)
            {
                result.Add(b.GetBinding());
            }
            return result.GetBindingAttribute(this.CreateData());
        }

        public string Start()
        {
            if (!this.IsUsingTag)
            {
                return string.Format(@"<!-- ko {0} -->", GetDataBind());
            }
            TagBuilder.Attributes.Add("data-bind", GetDataBind());
            return TagBuilder.ToString(TagRenderMode.StartTag);
        }

        public string End()
        {
            if (!this.IsUsingTag)
            {
                return @"<!-- /ko -->";
            }
            return TagBuilder.ToString(TagRenderMode.EndTag);
        }

        public override void WriteStart(TextWriter writer)
        {
            if (this.WriteTag)
            {
                writer.WriteLine(Start());
            }
        }

        protected override void WriteEnd(TextWriter writer)
        {
            if (this.WriteTag)
            {
                writer.WriteLine(End());
            }
        }

        protected abstract IKnockoutBindingItem GetBinding();

    }

}