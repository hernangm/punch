using System;
using System.IO;
using System.Linq.Expressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using Punch.Context;
using Moq;
using Punch.Core;

namespace Punch.Base.Tests
{
    public abstract class BaseTest
    {
        protected Mock<HttpContextBase> HttpContext { get; private set; }

        protected BaseTest()
        {
            KnockoutMetadataProviders.RegisterMetadataProvider(new KnockoutMvcMetadataProvider());
            this.HttpContext = new Mock<HttpContextBase>();
            this.HttpContext.Setup(m => m.Cache).Returns(HttpRuntime.Cache);
        }

        protected KnockoutHtmlContext<TModel> CreateHtmlContext<TModel>()
        {
            return new KnockoutHtmlContext<TModel>(GetViewContextMockOf<TModel>().Object, CreateKnockoutContext<TModel>());
        }

        protected TTag CreateKnockoutTag<TTag, TModel>(Expression<Func<TModel, object>> binding)
        {
            return (TTag)Activator.CreateInstance(typeof(TTag), CreateKnockoutContext<TModel>(), binding, null, null);
        }

        protected KnockoutContext<TModel> CreateKnockoutContext<TModel>()
        {
            return CreateKnockoutContext<TModel>(GetViewContextMockOf<TModel>().Object);
        }

        protected KnockoutContext<TModel> CreateKnockoutContext<TModel>(ViewContext viewContext)
        {
            return new KnockoutContext<TModel>(viewContext, (TModel)viewContext.ViewData.Model);
        }

        protected Mock<ViewContext> GetViewContextMockOf<TType>()
        {
            ViewDataDictionary vd = new ViewDataDictionary();
            vd.Model = Activator.CreateInstance(typeof(TType));
            return GetViewContextMock(vd);
        }

        private Mock<ViewContext> GetViewContextMock(ViewDataDictionary viewData)
        {
            var mock = new Mock<ViewContext>();
            mock.SetupGet(v => v.HttpContext).Returns(HttpContext.Object);
            mock.SetupGet(v => v.Controller).Returns(new Mock<ControllerBase>().Object);
            mock.SetupGet(v => v.View).Returns(new Mock<IView>().Object);
            mock.SetupGet(v => v.ViewData).Returns(viewData);
            mock.SetupGet(v => v.TempData).Returns(new TempDataDictionary());
            mock.SetupGet(v => v.RouteData).Returns(new RouteData());
            mock.SetupGet(v => v.Writer).Returns(new StringWriter());
            return mock;
        }
    }
}
