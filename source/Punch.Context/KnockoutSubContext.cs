using System.Collections.Generic;
using Punch.Contracts;

namespace Punch.Context
{
    public abstract class KnockoutSubContext<TModel> 
    {
        public KnockoutContext<TModel> Context { get; private set; }
        public string[] InstanceNames { get; private set; }
        public Dictionary<string, string> Aliases { get; private set; }

        protected KnockoutSubContext(KnockoutContext<TModel> context, string[] instanceNames = null, Dictionary<string, string> aliases = null)
        {
            Context = context;
            InstanceNames = instanceNames;
            Aliases = aliases;
        }

        protected KnockoutExpressionData CreateData()
        {
            var data = new KnockoutExpressionData();
            if (InstanceNames != null)
            {
                data.InstanceNames = InstanceNames;
            }
            if (Aliases != null)
            {
                data.Aliases = Aliases;
            }
            return data.Clone();
        }
    }
}
