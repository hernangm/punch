using Punch.Context;

namespace Punch.Helpers
{
    public static class KnockoutContextInputExtensions
    {
        #region ApplyBindings
        public static KnockoutBindingApplier ApplyBindings<TModel>(this KnockoutContext<TModel> context)
            
        {
            return new KnockoutBindingApplier(context.ViewContext);
        }
        #endregion
    }
}
