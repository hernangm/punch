using Punch.Base.Tests;
using NUnit.Framework;

namespace Punch.Helpers.Tests
{
    public class KnockoutContextTests : BaseTest
    {
        [Test]
        public void check_foreach_context()
        {
            var context = base.CreateKnockoutContext<ContextViewModel>();
            var child = context.ForEach(m => m.Children);
            child.Html.SpanFor(m=> m.Name);
            Assert.IsNull(child.Model);
        }

        [Test]
        public void check_with_context()
        {
            var context = base.CreateKnockoutContext<ContextViewModel>();
            var subcontext = context.With(m => m.SubContext);
            Assert.AreEqual(context.Model.SubContext, subcontext.Model);
        }
    }
}
