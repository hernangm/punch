using System;
using System.Text.RegularExpressions;
using Punch.Core;

namespace Punch.Bindings
{

    public class BindingNameResolver : NameResolverBase
    {
        protected override string GetConventionalName(Type type)
        {
            return Regex.Match(type.ToTypeNameWithoutGenericArity(), "(?<=^Knockout)(.*)(?=Binding$)").Value;
        }
    }
}
