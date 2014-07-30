using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public abstract class KnockoutBindingItem : IKnockoutBindingItem
    {
        public string Name { get { return new BindingNameResolver().GetName(this.GetType(), this.CustomName, this.CasePolicy); } }

        private string CustomName { get; set; }
        private NameCaseTypes CasePolicy { get; set; }

        protected KnockoutBindingItem()
        {
            this.CasePolicy = NameCaseTypes.CamelCase;
        }

        protected void SetCustomName(string customName)
        {
            this.CustomName = customName;
        }

        protected void SetCasePolicy(NameCaseTypes casePolicy)
        {
            this.CasePolicy = casePolicy;
        }

        public abstract string GetKnockoutExpression(KnockoutExpressionData data);

        public virtual bool IsValid()
        {
            return true;
        }
    }
}