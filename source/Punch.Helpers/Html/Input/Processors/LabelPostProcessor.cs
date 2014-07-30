using Punch.Helpers;

namespace Punch.Helpers
{


    public class LabelPostProcessor : ITagProcessor
    {
        public string PostProcess(object field, string output)
        {
            var input = field as IField;
            if (!input.Label.MustShow)
            {
                return output;
            }
            if (input.Label.WrappingLabel)
            {
                return string.Format(input.Label.ToHtmlString(), output);
            }
            else
            {
                return input.Label.ToHtmlString() + output;
            }
        }

        public bool CanProcess(object field)
        {
            return (field as IInput) != null;
        }

        public void PreProcess(object field)
        {
        }


    }
}
