using System;

namespace Punch.Core
{

    public abstract class NameResolverBase
    {
        public string GetName(Type type)
        {
            return GetName(type, null);
        }

        public string GetName(Type type, string customName, NameCaseTypes casePolicy = NameCaseTypes.CamelCase)
        {
            if (!string.IsNullOrEmpty(customName))
            {
                return customName;
            }
            var name = GetConventionalName(type);
            switch (casePolicy)
            {
                case NameCaseTypes.LowerCase:
                    return name.ToLower();
                case NameCaseTypes.CamelCase:
                    return name.ToCamelCase();
                default:
                    return name;
            }

        }

        protected abstract string GetConventionalName(Type type);

    }
}
