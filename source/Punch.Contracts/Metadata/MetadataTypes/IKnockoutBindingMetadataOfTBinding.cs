using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.Contracts
{
    public interface IKnockoutBindingMetadata<TBinding> : IKnockoutBindingMetadata where TBinding : IKnockoutBindingItem
    {
        TBinding Binding { get; }
    }
}
