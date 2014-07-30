using Punch.Contracts;
using Punch.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Punch.Context
{
    public class KnockoutMvcMetadataProvider : KnockoutMetadataProvider
    {
        private ModelMetadataProvider _ModelMetadataProvider { get; set; }
        protected ModelMetadataProvider ModelMetadataProvider
        {
            get
            {
                if (_ModelMetadataProvider == null)
                {
                    var current = ModelMetadataProviders.Current;
                    if (current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    _ModelMetadataProvider = ModelMetadataProviders.Current;
                }
                return _ModelMetadataProvider;
            }
        }

        public IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
        {
            return this.ModelMetadataProvider.GetMetadataForProperties(container, containerType);
        }

        public ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            return this.ModelMetadataProvider.GetMetadataForProperty(modelAccessor, containerType, propertyName);
        }

        public ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
        {
            return this.ModelMetadataProvider.GetMetadataForType(modelAccessor, modelType);
        }
    }
}
