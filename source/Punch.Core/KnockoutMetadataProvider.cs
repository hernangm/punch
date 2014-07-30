using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Punch.Contracts;

namespace Punch.Core
{
    public static class KnockoutMetadataProviders
    {
        private static KnockoutMetadataProvider MetadataProvider { get; set; }

        public static void RegisterMetadataProvider(KnockoutMetadataProvider metadataProvider)
        {
            MetadataProvider = metadataProvider;
        }

        public static KnockoutMetadataProvider Current { get { return MetadataProvider; } }
    }

    public abstract class KnockoutMetadataProvider
    {

        public bool Contains<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata
        {
            return false;
        }

        public TMetadata FirstOrDefault<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata
        {
            return default(TMetadata);
        }

        public IEnumerable<TMetadata> Where<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata
        {
            return new List<TMetadata>();
        }

        public bool ContainsBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return false;
        }

        public IEnumerable<IKnockoutBindingMetadata> WhereBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return new List<IKnockoutBindingMetadata>();
        }

        public bool ContainsExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return false;
        }

        public IKnockoutExtendedObservableMetadata FirstOrDefaultExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return null;
        }
    }

}
