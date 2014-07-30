using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Punch.Helpers
{
    public interface ITag : IHtmlString
    {
        string GetId();
        void AddClass1(string @class);
    }

    public interface ITag<TTag> : ITag where TTag : ITag
    {
        //TTag AddClass(string @class);
        void RegisterProcessor(ITagProcessor processor);
        bool ContainsProcessor<TProcessor>() where TProcessor : ITagProcessor;
        TProcessor GetProcessor<TProcessor>() where TProcessor : ITagProcessor;
    }
}
