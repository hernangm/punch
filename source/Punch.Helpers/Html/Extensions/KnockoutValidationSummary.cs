
using System.Web.Mvc;
using Punch.Bindings;
namespace Punch.Helpers
{

    public class KnockoutValidationSummary : KnockoutTagBaseOfString<KnockoutValidationSummary>
    {
        private const string template = "<!-- ko if: {0}().length > 0 --><div class=\"msg error\"><ul data-bind=\"foreach:{0}\"><li data-bind=\"text: $data\"></li></ul></div><!-- /ko -->";
        private string Scope { get; set; }

        public KnockoutValidationSummary()
            : this(null, null)
        {
        }

        public KnockoutValidationSummary(string errorCollectionVariable, string scope = null)
            : base("div", errorCollectionVariable)
        {
            this.Scope = scope;
        }

        protected override void ConfigureTagBuilder(TagBuilder tagBuilder)
        {
            base.ConfigureTagBuilder(tagBuilder);
            var propertyName = this.GetPropertyName();
            var salida = string.Format(template, propertyName);
            tagBuilder.InnerHtml += string.IsNullOrEmpty(this.Scope) ? salida : string.Format("<!-- ko with:{0} -->{1}<!-- /ko -->", this.Scope, salida);

        }

        protected override string GetPropertyName()
        {
            var prop = base.GetPropertyName();
            return !string.IsNullOrEmpty(prop) ? prop : "Errors";
        }

        protected override void ConfigureBinding(KnockoutBindingCollection bindings)
        {
        }
    }
}
