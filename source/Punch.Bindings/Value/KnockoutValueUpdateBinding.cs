using System;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{

    public class KnockoutValueUpdateBinding : KnockoutBindingStringItem
    {
        public KnockoutValueUpdateBinding(KnockoutValueUpdateKind kind)
            : base("valueUpdate", Enum.GetName(typeof(KnockoutValueUpdateKind), kind).ToLower(), true)
        { }
    }

    public static class KnockoutValueUpdateBindingExtensions
    {
        public static TReturn ValueUpdate<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, KnockoutValueUpdateKind binding)
                        where TReturn : IKnockoutBindingCollection
        {
            bindings.Add(new KnockoutValueUpdateBinding(binding));
            return bindings.ReturnObject;
        }
    }
}
