using System.Web;

namespace Punch.Helpers
{
    public interface IField : ITag
    {
        FieldType Type { get; }
        KnockoutLabel Label { get; }
    }

    public interface IField<TType> : IField, ITag<TType> where TType : IField
    {
    }
}
