using Prism.Ioc;
using Prism.Modularity;

namespace Shell.Bases
{
    public abstract class ModuleBase : IModule
    {
        #region Public methods

        public void OnInitialized(IContainerProvider containerProvider)
        {
            OnModuleInitialized(containerProvider);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Allows register module-specific instances/services
        }

        #endregion //Public methods

        #region Private methods

        protected virtual void OnModuleInitialized(IContainerProvider containerProvider)
        {
            //Allows other necessities when initializing a module
        }

        protected virtual void RegisterModuleTypes(IContainerProvider containerProvider)
        {
            //Allows other necessities when initializing a module
        }

        #endregion //Private methods
    }
}
