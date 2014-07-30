using System;
using System.Collections.Generic;

namespace Punch.Contracts
{
    public interface IKnockoutMetadataDictionary : IDictionary<string, object>
    {
        void SetThis(object value);
    }
}
