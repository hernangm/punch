
namespace Punch.Contracts
{
    public interface IKnockoutBindingComplexItem: IKnockoutBindingItem
    {
        void Add(IKnockoutBindingItem subItem);
    }
}
