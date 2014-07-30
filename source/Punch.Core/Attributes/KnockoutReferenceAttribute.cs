using System;

namespace Punch.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class KnockoutReferenceAttribute : KnockoutBaseAttribute
    {
    }
}
