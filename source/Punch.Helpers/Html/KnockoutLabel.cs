using System.Web;
using System.Web.Mvc;

namespace Punch.Helpers
{
    public class KnockoutLabel : IHtmlString
    {
        private IField Field { get; set; }
        public string Text { get; set; }
        public bool MustShow { get; set; }

        public KnockoutLabel(IField field, string text)
        {
            this.Field = field;
            this.MustShow = true;
            this.Text = text;
        }

        public bool WrappingLabel
        {
            get
            {
                var input = Field as IInput;
                if (input != null)
                {
                    return input.InputType == InputType.CheckBox || input.InputType == InputType.Radio;
                }
                else
                {
                    return false;
                }
            }
        }


        public string ToHtmlString()
        {
            var label = new TagBuilder("label");
            label.Attributes.Add("for", Field.GetId());
            if (this.WrappingLabel)
            {
                label.AddCssClass((Field as IInput).InputType.ToString().ToLowerInvariant());
                label.InnerHtml = "{0}";
            }
            label.InnerHtml += GetLabelText();
            return label.ToString();
        }

        private string GetLabelText()
        {
            //if (Metadata != null)
            //{
            //    var metadataLabel = Metadata.FirstOrDefault(m => m.GetType() == typeof(LabelConfig)) as LabelConfig;
            //    if (metadataLabel != null)
            //    {
            //        return metadataLabel.ResourceKey;
            //    }
            //}
            return this.Text;
        }

    }
}
