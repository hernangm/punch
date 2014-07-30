using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.Helpers
{
    public static class FieldExtensions
    {
        public static TType Size<TType>(this IField<TType> field, int size) where TType : IField
        {
            if (size > 0)
            {
                field.AddClass1(string.Format("span{0}", size));
            }
            return (TType)field;
        }

        public static TType WithLabel<TType>(this IField<TType> field, string label) where TType : IField
        {
            field.Label.MustShow = true;
            field.Label.Text = label;
            return (TType)field;
        }

        public static TType WithoutLabel<TType>(this IField<TType> field) where TType : IField
        {
            field.Label.MustShow = false;
            return (TType)field;
        }
    }
}
