using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Punch.Context;

namespace Punch.Helpers
{
    public class KnockoutHelper<TModel> 
    {
        private static readonly string Key = "ko_key";

        private ViewDataDictionary ViewData { get; set; }
        private HtmlHelper<TModel> Helper { get; set; }
        private KnockoutContext<TModel> _CurrentContext { get; set; }

        public KnockoutHelper(HtmlHelper<TModel> helper, IViewDataContainer viewDataContainer)
            : this(helper, viewDataContainer, RouteTable.Routes) { }

        public KnockoutHelper(HtmlHelper<TModel> helper, IViewDataContainer container, RouteCollection routeCollection)
        {
            this.Helper = helper;
            ViewData = new ViewDataDictionary<TModel>(container.ViewData);
        }

        public void RenderPartial<TChild>(string partialViewName, KnockoutWithContext<TChild, TModel> context)
        {
            //ojo aca, hay que dejar bien identificado el contexto
            var key = string.Format("ko_context_{0}", partialViewName);
            if (!this.ViewData.ContainsKey(key))
            {
                this.ViewData[Key] = key;
                this.ViewData.Add(key, context);
            }

            this.Helper.RenderPartial(partialViewName, context.Model, ViewData);
        }

        public KnockoutContext<TModel> CurrentContext
        {
            get
            {
                if (this._CurrentContext == null)
                {
                    TModel model;
                    if (this.Helper.ViewData.ContainsKey(Key))
                    {
                        var key = (string)this.Helper.ViewData[Key];
                        var context = (KnockoutContext<TModel>)this.Helper.ViewData[key];
                        model = context.Model;
                    }
                    else
                    {
                        model = (TModel)this.Helper.ViewContext.ViewData.Model;
                    }
                    this._CurrentContext = new KnockoutContext<TModel>(this.Helper.ViewContext, model);

                }
                return this._CurrentContext;
            }
        }
    }

}
