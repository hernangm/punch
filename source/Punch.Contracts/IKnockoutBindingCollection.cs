
namespace Punch.Contracts
{
    public interface IKnockoutBindingCollection
    {
        void Add(IKnockoutBindingItem binding);
        void Add<TComplex>(IKnockoutBindingItem binding) where TComplex : IKnockoutBindingComplexItem;
        string GetBindingAttribute(KnockoutExpressionData data);
    }

    public interface IKnockoutBindingCollection<TReturn> : IKnockoutBindingCollection
        where TReturn : IKnockoutBindingCollection
    {
        TReturn ReturnObject { get; }
    }

    public interface IKnockoutBindingCollection<TReturn, TModel> : IKnockoutBindingCollection<TReturn>
        where TReturn : IKnockoutBindingCollection
    {
    }
}
