
namespace Punch.Contracts
{
    public interface IKnockoutBindingItem
    {
        string GetKnockoutExpression(KnockoutExpressionData data);
        bool IsValid();
        string Name { get; }
    }
}
