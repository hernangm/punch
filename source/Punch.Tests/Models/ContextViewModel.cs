using System.Collections.Generic;

namespace Punch.Tests
{

    public class ContextViewModel
    {
        public SubContextViewModel SubContext { get; set; }
        public IList<ChildrenViewModel> Children { get; set; }

        public ContextViewModel()
        {
            this.SubContext = new SubContextViewModel();
            this.Children = new List<ChildrenViewModel>();
        }

    }

    public class SubContextViewModel
    {

    }

    public class ChildrenViewModel
    {
        public string Name { get; set; }
    }
}
