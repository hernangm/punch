using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;

namespace Punch.Context
{
    public class KnockoutIfContext<TModel> : KnockoutCommonRegionContext<TModel, TModel, bool> 
    {
        public KnockoutIfContext(ViewContext viewContext, Expression<Func<TModel, bool>> expression, string tag)
            : base(viewContext, expression, tag)
        {
        }

        public KnockoutIfContext(ViewContext viewContext, Expression<Func<TModel, bool>> expression)
            : this(viewContext, expression, null)
        {
        }



        protected override IKnockoutBindingItem GetBinding()
        {
            return new KnockoutIfBinding<TModel>(this.Expression);
        }
    }
}