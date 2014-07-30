using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;

namespace Punch.Context
{
    public class KnockoutWithContext<TChild, TParent> : KnockoutCommonRegionContext<TChild, TParent, TChild>
    {
        public KnockoutWithContext(ViewContext viewContext, Expression<Func<TParent, TChild>> binding, TParent parent, TChild child, string tag, bool writeTag = true)
            : base(viewContext, binding, tag, writeTag)
        {
            base.SetModel(child);
        }

        public KnockoutWithContext(ViewContext viewContext, Expression<Func<TParent, TChild>> binding, TParent parent, TChild child)
            : this(viewContext, binding, parent, child, null)
        {
        }

        protected override IKnockoutBindingItem GetBinding()
        {
            return new KnockoutWithBinding<TParent, TChild>(this.Expression);
        }
    }
}