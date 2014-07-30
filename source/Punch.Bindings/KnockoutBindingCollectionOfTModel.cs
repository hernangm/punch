using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutBindingCollection<TModel> : KnockoutBindingCollectionBase, IKnockoutBindingCollection<KnockoutBindingCollection<TModel>, TModel> 
    {
        public KnockoutBindingCollection() : base() { }

        public KnockoutBindingCollection(KnockoutExpressionData data) : base(data) { }

        public KnockoutBindingCollection<TModel> ReturnObject { get { return this; } }
    }
}
