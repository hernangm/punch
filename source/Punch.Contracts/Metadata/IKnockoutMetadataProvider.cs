using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Punch.Contracts
{
    public interface IKnockoutMetadataProvider
    {
        //IMetadataDescriptor GetMetadata(Type type);

        #region general
        bool Contains<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata;

        TMetadata FirstOrDefault<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata;

        IEnumerable<TMetadata> Where<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IKnockoutMetadata;
        #endregion

        #region bindings
        bool ContainsBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding);

        IEnumerable<IKnockoutBindingMetadata> WhereBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding);
        #endregion

        #region extends
        bool ContainsExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding);
        IKnockoutExtendedObservableMetadata FirstOrDefaultExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding);
        #endregion
    }
}
