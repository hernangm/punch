using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;

namespace Punch.Context
{
    public class KnockoutForEachContext<TChild, TParent> : KnockoutCommonRegionContext<TChild, TParent, IList<TChild>>
    {
        public KnockoutForEachContext(ViewContext viewContext, Expression<Func<TParent, IList<TChild>>> binding, string tag)
            : base(viewContext, binding, tag)
        {
        }

        public KnockoutForEachContext(ViewContext viewContext, Expression<Func<TParent, IList<TChild>>> binding)
            : this(viewContext, binding, null)
        {
        }

        protected override IKnockoutBindingItem GetBinding()
        {
            return new KnockoutForEachBinding<TParent, TChild>(this.Expression);
        }
    }
}
