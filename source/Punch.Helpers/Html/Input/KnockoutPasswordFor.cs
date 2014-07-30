using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutPassword : KnockoutInputBase<KnockoutPassword>
    {
        public KnockoutPassword(string property)
            : base(InputType.Password, property)
        {
        }
    }

    public static class KnockoutPasswordForExtensions
    {
        public static KnockoutPassword<TModel> PasswordFor<TModel>(this KnockoutHtmlContext<TModel> html, Expression<Func<TModel, object>> binding)
        {
            var data = html.Context.CreateData();
            return new KnockoutPassword<TModel>(html.Context, binding, data.InstanceNames, data.Aliases);
        }
    }
}
