using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;


namespace Punch.Helpers
{
    public class KnockoutTextBox<TModel> : KnockoutTextInputBase<KnockoutTextBox<TModel>, TModel> 
    {
        public KnockoutTextBox(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Text, binding, instancesNames, aliases)
        {
        }
    }

    public static class KnockoutTextBoxForExtensions
    {
        public static KnockoutTextBox<TModel> TextBoxFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutTextBox<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }

}
