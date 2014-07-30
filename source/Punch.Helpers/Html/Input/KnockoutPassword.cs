using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutPassword<TModel> : KnockoutInputBase<KnockoutPassword<TModel>, TModel> 
    {
        public KnockoutPassword(KnockoutContext<TModel> context, Expression<Func<TModel, object>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(context, InputType.Password, binding, instancesNames, aliases)
        {
        }
    }
}
