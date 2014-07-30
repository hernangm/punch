using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutUniqueNameBinding : KnockoutBindingStringItem
    {
        public KnockoutUniqueNameBinding() : base("true", false) { }
    }

    public static class KnockoutUniqueNameBindingExtensions
    {
        public static TReturn UniqueName<TReturn>(this IKnockoutBindingCollection<TReturn> bindings)
            where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutUniqueNameBinding());
            return bindings.ReturnObject;
        }
    }
}
