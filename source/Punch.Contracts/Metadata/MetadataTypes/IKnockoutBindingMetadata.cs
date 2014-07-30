
namespace Punch.Contracts
{
    public interface IKnockoutBindingMetadata : IKnockoutMetadata
    {
        bool ShouldReplace { get; }
        IKnockoutBindingItem GetBinding();
    }
}
