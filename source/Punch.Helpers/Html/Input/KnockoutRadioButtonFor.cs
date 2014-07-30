using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;


namespace Punch.Helpers
{
    public class KnockoutRadioButton<TModel> : KnockoutCheckedInputBase<KnockoutRadioButton<TModel>, TModel> 
    {
        public KnockoutRadioButton(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Radio, binding, instancesNames, aliases)
        {
        }
    }

    public static class KnockoutRadioButtonForExtensions
    {
        public static KnockoutRadioButton<TModel> RadioButtonFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutRadioButton<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}