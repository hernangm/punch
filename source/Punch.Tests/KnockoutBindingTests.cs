using System.Web;
using Punch.Bindings;
using NUnit.Framework;

namespace Punch.Tests
{
    public class KnockoutBindingTests : BaseTest
    {

        [Test]
        public void Prueba()
        {
            var context = CreateKnockoutContext<HtmlViewModel>();
            var bindings = context.Bind.Text(m => m.Html);
            Assert.AreEqual(@"html : Html", bindings.GetBindingAttribute(context.CreateData()));
        }

        [Test]
        public void HtmlBindingTest()
        {
            var htmlContext = CreateHtmlContext<HtmlViewModel>();
            var binding = new KnockoutHtmlBinding<HtmlViewModel, IHtmlString>(m => m.Html);
            Assert.AreEqual(@"html : Html", binding.GetKnockoutExpression(htmlContext.Context.CreateData()));

            var binding2 = new KnockoutHtmlBinding<HtmlViewModel, IHtmlString>(m => m.Html2);
            Assert.AreEqual(@"html : Html2", binding2.GetKnockoutExpression(htmlContext.Context.CreateData()));
        }

        [Test]
        public void click_binding()
        {
            var htmlContext = CreateHtmlContext<TestViewModel>();
            var binding = new KnockoutClickBinding<TestViewModel>(m => m.Click);
            Assert.AreEqual(@"click : Click", binding.GetKnockoutExpression(htmlContext.Context.CreateData()));
        }
    }



}
