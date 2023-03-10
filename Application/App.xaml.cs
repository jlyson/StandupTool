using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Shell.Interfaces;
using Shell.Services;
using Shell.Views.MainWindow;
using System;
using System.Reflection;
using System.Windows;

namespace Shell
{
    public partial class App : PrismApplication
    {
        #region Override methods

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindowView>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                string viewName = viewType.FullName ?? String.Empty;
                string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName ?? String.Empty;
                string viewModelName = $"{viewName}Model, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            return base.CreateContainerExtension();
            //Allows registering single implementation under multiple services
            //return PrismContainerExtension.Current;
        }

        protected override Rules CreateContainerRules()
        {
            return Rules.Default.WithAutoConcreteTypeResolution()
                .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
                .WithDefaultIfAlreadyRegistered(IfAlreadyRegistered.AppendNewImplementation)
                .WithoutThrowOnRegisteringDisposableTransient();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISplashScreenService, SplashScreenService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            //Add custom modules
        }

        protected override void InitializeModules()
        {
            ISplashScreenService splashScreenService = Container.Resolve<ISplashScreenService>();

            splashScreenService.OpenSplashScreen();
            base.InitializeModules();
            splashScreenService.CloseSplashScreen();
        }

        #endregion //Override methods
    }
}