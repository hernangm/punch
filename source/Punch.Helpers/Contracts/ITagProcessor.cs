
namespace Punch.Helpers
{
    public interface ITagProcessor
    {
        void PreProcess(object field);
        string PostProcess(object field, string output);
        bool CanProcess(object field);
    }
}
