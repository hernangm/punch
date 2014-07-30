using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Context
{
    public class KnockoutContext<TModel> : IKnockoutContext<TModel>
    {
        private TModel model = default(TModel);

        public KnockoutMvcMetadataProvider MetadataProvider { get; private set; }
        protected IList<IKnockoutContext> ContextStack { get; private set; }
        public ViewContext ViewContext { get; private set; }

        public TModel Model
        {
            get
            {
                return model;
            }
        }

        private KnockoutContext()
        {
            this.MetadataProvider = new KnockoutMvcMetadataProvider();
            ContextStack = new List<IKnockoutContext>() { this };
        }

        public KnockoutContext(ViewContext viewContext)
            : this()
        {
            this.ViewContext = viewContext;
        }

        public KnockoutContext(ViewContext viewContext, TModel model)
            : this(viewContext)
        {
            this.SetModel(model);
        }

        protected void SetModel(TModel model)
        {
            this.model = model;
        }


        public void AddToContextStack(IKnockoutContext context)
        {
            this.ContextStack.Add(context);
        }

        private int ActiveSubcontextCount
        {
            get
            {
                return ContextStack.Count - 1 - ContextStack.IndexOf(this);
            }
        }

        public KnockoutForEachContext<TItem, TModel> ForEach<TItem>(Expression<Func<TModel, IList<TItem>>> binding)
        {
            return ForEach<TItem>(null, binding, null);
        }

        public KnockoutForEachContext<TItem, TModel> ForEach<TItem>(string tag, Expression<Func<TModel, IList<TItem>>> binding)
        {
            return ForEach<TItem>(tag, binding, null);
        }

        public KnockoutForEachContext<TItem, TModel> ForEach<TItem>(string tag, Expression<Func<TModel, IList<TItem>>> binding, object attributes)
        {
            var regionContext = new KnockoutForEachContext<TItem, TModel>(ViewContext, binding, tag);
            if (attributes != null)
            {
                regionContext.AddAttributes(attributes);
            }
            regionContext.WriteStart(ViewContext.Writer);
            regionContext.ContextStack = ContextStack;
            ContextStack.Add(regionContext);
            return regionContext;
        }

        public KnockoutWithContext<TItem, TModel> With<TItem>(Expression<Func<TModel, TItem>> binding)
        {
            return PrivateWith(binding, null);
        }

        public KnockoutWithContext<TItem, TModel> With<TItem>(Expression<Func<TModel, TItem>> binding, bool writeTag)
        {
            return PrivateWith(binding, null, writeTag);
        }

        public KnockoutWithContext<TItem, TModel> With<TItem>(Expression<Func<TModel, TItem>> binding, string tag)
        {
            return PrivateWith(binding, tag);
        }

        private KnockoutWithContext<TItem, TModel> PrivateWith<TItem>(Expression<Func<TModel, TItem>> binding, string tag, bool writeTag = true)
        {
            // ESTO PARA PASAR EL MODELO HACIA ABAJO
            var parent = (ContextStack[ContextStack.Count - 1] as IKnockoutContext<TModel>).Model;
            if (parent == null)
            {
                parent = Activator.CreateInstance<TModel>();
            }
            Func<TModel, TItem> func = binding.Compile();
            var item = (TItem)func((TModel)parent);
            var regionContext = new KnockoutWithContext<TItem, TModel>(ViewContext, binding, parent, item, tag, writeTag);
            regionContext.WriteStart(ViewContext.Writer);
            regionContext.ContextStack = ContextStack;
            //todo: revisar el stack para setear el modelo para que funcione en muchas profundidades
            ContextStack.Add(regionContext);
            return regionContext;
        }

        public KnockoutIfContext<TModel> If(Expression<Func<TModel, bool>> binding)
        {
            var regionContext = new KnockoutIfContext<TModel>(ViewContext, binding);
            regionContext.InStack = false;
            regionContext.WriteStart(ViewContext.Writer);
            return regionContext;
        }

        public string GetInstanceName()
        {
            switch (ActiveSubcontextCount)
            {
                case 0:
                    return "";
                case 1:
                    return "$parent";
                default:
                    return "$parents[" + (ActiveSubcontextCount - 1) + "]";
            }
        }

        private string GetContextPrefix()
        {
            var sb = new StringBuilder();
            int count = ActiveSubcontextCount;
            for (int i = 0; i < count; i++)
                sb.Append("$parentContext.");
            return sb.ToString();
        }

        public string GetIndex()
        {
            return GetContextPrefix() + "$index()";
        }

        public virtual KnockoutExpressionData CreateData()
        {
            return new KnockoutExpressionData { InstanceNames = new[] { GetInstanceName() } };
        }


        public virtual KnockoutBindingCollection<TModel> Bind
        {
            get
            {
                return new KnockoutBindingCollection<TModel>(CreateData());
            }
        }

        public virtual KnockoutHtmlContext<TModel> Html
        {
            get
            {
                return new KnockoutHtmlContext<TModel>(ViewContext, this, CreateData().InstanceNames, CreateData().Aliases);
            }
        }



    }

}
