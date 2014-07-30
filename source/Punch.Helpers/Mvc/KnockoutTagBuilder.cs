using System.Collections.Generic;
using System.Web.Mvc;
using Punch.Bindings;

namespace Punch.Helpers
{
    public class KnockoutTagBuilder
    {
        private TagBuilder TagBuilder { get; set; }
        public KnockoutBindingCollection Bindings { get; private set; }

        public KnockoutTagBuilder(string tagName)
        {
            this.TagBuilder = new TagBuilder(tagName);
            this.Bindings = new KnockoutBindingCollection();
        }

        public IDictionary<string, string> Attributes { get { return this.TagBuilder.Attributes; } }

        public string IdAttributeDotReplacement
        {
            get { return this.TagBuilder.IdAttributeDotReplacement; }
            set { this.TagBuilder.IdAttributeDotReplacement = value; }
        }

        public string InnerHtml
        {
            get { return this.TagBuilder.InnerHtml; }
            set { this.TagBuilder.InnerHtml = value; }
        }

        public string TagName { get { return this.TagBuilder.TagName; } }

        public void AddCssClass(string value)
        {
            this.TagBuilder.AddCssClass(value);
        }

        public static string CreateSanitizedId(string originalId)
        {
            return TagBuilder.CreateSanitizedId(originalId);
        }

        public static string CreateSanitizedId(string originalId, string invalidCharReplacement)
        {
            return TagBuilder.CreateSanitizedId(originalId, invalidCharReplacement);
        }

        public void GenerateId(string name)
        {
            this.TagBuilder.GenerateId(name);
        }

        public void MergeAttribute(string key, string value)
        {
            this.TagBuilder.MergeAttribute(key, value);
        }

        public void MergeAttribute(string key, string value, bool replaceExisting)
        {
            this.TagBuilder.MergeAttribute(key, value, replaceExisting);
        }

        public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            this.TagBuilder.MergeAttributes<TKey, TValue>(attributes);
        }

        public void MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
        {
            this.TagBuilder.MergeAttributes<TKey, TValue>(attributes, replaceExisting);

        }

        public void SetInnerText(string innerText)
        {
            this.TagBuilder.SetInnerText(innerText);
        }

        public override string ToString()
        {
            BeforeRender();
            return TagBuilder.ToString();
        }

        public string ToString(TagRenderMode renderMode)
        {
            BeforeRender();
            return TagBuilder.ToString(renderMode);
        }

        private void BeforeRender()
        {
            this.TagBuilder.Attributes["data-bind"] = this.Bindings.GetBindingAttribute(null);
        }

    }
}
