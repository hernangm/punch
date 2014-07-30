using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Bindings;
using Punch.Context;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Helpers
{
    public abstract class KnockoutTagBaseOfTModel<TType, TModel, TItem> : KnockoutTagBase<TType, KnockoutBindingCollection<TModel>>, IKnockoutBindingCollection<TType, TModel> 
        where TType : KnockoutTagBaseOfTModel<TType, TModel, TItem>
        
    {
        #region "Properties"
        private string PropertyName { get; set; }

        protected Expression<Func<TModel, TItem>> Binding { get; set; }
        protected KnockoutContext<TModel> Context { get; set; }
        protected string[] InstanceNames { get; set; }
        protected Dictionary<string, string> Aliases { get; set; }

        protected bool AddBindingsDefinedThroughMetadata { get; set; }
        #endregion

        public KnockoutTagBaseOfTModel(string tagName, KnockoutContext<TModel> context, Expression<Func<TModel, TItem>> binding, string[] instancesNames = null, Dictionary<string, string> aliases = null)
            : base(tagName, new KnockoutBindingCollection<TModel>())
        {
            this.Context = context;
            this.Binding = binding;
            this.InstanceNames = instancesNames;
            this.Aliases = aliases;
            this.AddBindingsDefinedThroughMetadata = true;
        }

        protected override void PreConfigureBinding(KnockoutBindingCollection<TModel> bindings)
        {
            base.PreConfigureBinding(bindings);
            this.AddMetadataBindings(bindings);
        }

        protected virtual IEnumerable<IKnockoutBindingMetadata> GetBindingMetadata()
        {
            return this.Context.MetadataProvider.WhereBindingMetadata(Binding);
        }

        protected void AddMetadataBindings(IKnockoutBindingCollection bindings, bool forceAdd = false)
        {
            if (AddBindingsDefinedThroughMetadata || forceAdd)
            {
                foreach (var k in GetBindingMetadata())
                {
                    bindings.Add(k.GetBinding());
                }
            }
        }


        protected override string GetBindingName()
        {
            return KnockoutExpressionConverter.Convert(this.Binding, this.Context.CreateData());
        }


        protected override string GetPropertyName()
        {
            if (string.IsNullOrEmpty(this.PropertyName))
            {
                this.PropertyName = KnockoutExpressionConverter.Convert(this.Binding, this.Context.CreateData(), false);
            }
            return this.PropertyName;
        }




    }

}
