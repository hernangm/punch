using Punch.Bindings;
using HtmlAgilityPack;
using NUnit.Framework;
using Punch.Helpers;

namespace Punch.Tests
{
    public class KnockoutHtmlTests : BaseTest
    {

        public HtmlNode Parse(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return htmlDoc.DocumentNode.FirstChild;
        }

        [Test]
        public void CustomBindingTest()
        {
            var input = this.CreateKnockoutTag<KnockoutTextBox<TestViewModel>, TestViewModel>(m => m.A).WithoutLabel();
            input.BindTo("html");
            var result = input.ToHtmlString();
            var node = Parse(result);
            Assert.AreEqual(node.Attributes["data-bind"].Value, "html : A");
        }

        [Test]
        public void AddBindingTest()
        {
            var input = this.CreateKnockoutTag<KnockoutTextBox<TestViewModel>, TestViewModel>(m => m.A).WithoutLabel();
            input.Custom("autocomplete", "Pepe");
            var result = input.ToHtmlString();
            var node = Parse(result);
            Assert.IsTrue(node.Attributes["data-bind"].Value.Contains("autocomplete : Pepe"));
        }

        [Test]
        public void ChainingBindings()
        {
            var input = new KnockoutButton<TestViewModel>(CreateKnockoutContext<TestViewModel>(), "Pepe", m => m.Click).Enable(m => m.Bool);
            var result = input.ToHtmlString();
            var node = Parse(result);
            Assert.IsTrue(node.Attributes["data-bind"].Value.Contains("click : Click"));
            Assert.IsTrue(node.Attributes["data-bind"].Value.Contains("enable : Bool"));
        }
    }
}
