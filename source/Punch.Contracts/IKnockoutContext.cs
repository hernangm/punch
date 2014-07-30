using System.Collections.Generic;
using System.Web.Mvc;

namespace Punch.Contracts
{
    public interface IKnockoutContext
    {
        string GetInstanceName();
        string GetIndex();
    }

    public interface IKnockoutContext<TModel> : IKnockoutContext
    {
        TModel Model { get; }
        ViewContext ViewContext { get; }
        KnockoutExpressionData CreateData();
        void AddToContextStack(IKnockoutContext context);
        //IList<IKnockoutContext> ContextStack { get; }
    }
}
