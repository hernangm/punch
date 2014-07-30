using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public abstract class KnockoutBindingCollectionBase : IHtmlString, IKnockoutBindingCollection
    {
        private readonly List<IKnockoutBindingItem> Items = new List<IKnockoutBindingItem>();
        private KnockoutExpressionData Data { get; set; }

        protected KnockoutBindingCollectionBase() { }

        protected KnockoutBindingCollectionBase(KnockoutExpressionData data)
        {
            this.Data = data;
        }

        protected KnockoutBindingCollectionBase(IEnumerable<KnockoutBindingItem> items, KnockoutExpressionData data)
            : this(data)
        {
            Guard.NotNull(() => items, items);
            this.Items.AddRange(items);
        }

        public void Add(IKnockoutBindingItem binding)
        {
            Items.Add(binding);
        }

        public void Add<TComplex>(IKnockoutBindingItem binding) where TComplex : IKnockoutBindingComplexItem
        {
            var complex = (TComplex)Items.FirstOrDefault(m => m.GetType() == typeof(TComplex));
            if (complex == null)
            {
                complex = Activator.CreateInstance<TComplex>();
                Items.Add(complex);
            }
            complex.Add(binding);
        }

        public string GetBindingAttribute(KnockoutExpressionData data)
        {
            var sb = new StringBuilder();
            bool first = true;
            foreach (var item in Items)
            {
                if (!item.IsValid())
                {
                    continue;
                }
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(',');
                }
                sb.Append(item.GetKnockoutExpression(data));
            }
            return sb.ToString();
        }

        //public IReadOnlyList<KnockoutBindingItem> GetItems()
        //{
        //    return this.Items.AsReadOnly();
        //}

        public string ToHtmlString()
        {
            return @"data-bind=""{0}""".FormatWith(this.GetBindingAttribute(this.Data));
        }


    }
}
