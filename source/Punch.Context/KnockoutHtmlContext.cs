using System.Collections.Generic;
using System.Web.Mvc;
using Punch.Contracts;

namespace Punch.Context
{
    public class KnockoutHtmlContext<TModel> : KnockoutSubContext<TModel>, IKnockoutHtmlContext
    {
        public ViewContext ViewContext { get; private set; }

        public KnockoutHtmlContext(ViewContext viewContext, KnockoutContext<TModel> context, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, instancesNames, aliases)
        {
            this.ViewContext = viewContext;
        }
    }
}
