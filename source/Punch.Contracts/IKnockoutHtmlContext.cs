using System.Web.Mvc;

namespace Punch.Contracts
{
    public interface IKnockoutHtmlContext
    {
        ViewContext ViewContext { get; }
    }
}
