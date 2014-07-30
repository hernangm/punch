using System.Web.Mvc;

namespace Punch.Helpers
{
    public interface IInput : IField
    {
        InputType InputType { get; }
    }
}
