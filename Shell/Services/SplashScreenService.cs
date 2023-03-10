using Prism.Ioc;
using Shell.Bases;
using Shell.Interfaces;
using Shell.Views.SplashScreen;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Shell.Services
{
    public class SplashScreenService : ServiceBase, ISplashScreenService
    {
        #region Data members

        private readonly IContainerExtension _ContainerExtension;

        private SplashScreenViewModel _currentlyOpenSplashScreenViewModel;
        private SplashScreenView _currentlyOpenSplashScreenView;

        #endregion //Data members

        #region Constructors

        public SplashScreenService(IContainerExtension containerExtension)
        {
            _ContainerExtension = containerExtension;
        }

        #endregion //Constructors

        #region Public methods

        public void OpenSplashScreen()
        {
            if (_currentlyOpenSplashScreenView != null)
                return;

            _currentlyOpenSplashScreenViewModel = _ContainerExtension.Resolve<SplashScreenViewModel>();
            _currentlyOpenSplashScreenView = _ContainerExtension.Resolve<SplashScreenView>();
            _currentlyOpenSplashScreenView.Show();
        }

        public void CloseSplashScreen()
        {
            if (_currentlyOpenSplashScreenView == null)
                return;

            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(350));
            animation.Completed += (s, _) =>
            {
                _currentlyOpenSplashScreenView?.Close();
                _currentlyOpenSplashScreenView = null;
                _currentlyOpenSplashScreenViewModel = null;
            };

            _currentlyOpenSplashScreenView.BeginAnimation(UIElement.OpacityProperty, animation, HandoffBehavior.SnapshotAndReplace);
        }

        #endregion //Public methods
    }
}