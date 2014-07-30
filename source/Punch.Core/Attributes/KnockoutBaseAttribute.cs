using System;

namespace Punch.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class KnockoutBaseAttribute : Attribute
    {
    }
}
