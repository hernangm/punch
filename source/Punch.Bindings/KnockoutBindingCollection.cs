using System.Collections.Generic;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{

    public class KnockoutBindingCollection : KnockoutBindingCollectionBase, IKnockoutBindingCollection<KnockoutBindingCollection>
    {
        public KnockoutBindingCollection() : base() { }

        public KnockoutBindingCollection(KnockoutExpressionData data) : base(data) { }

        public KnockoutBindingCollection(IEnumerable<KnockoutBindingItem> items, KnockoutExpressionData data)
            : base(items, data)
        { }

        public KnockoutBindingCollection ReturnObject { get { return this; } }
    }

}
