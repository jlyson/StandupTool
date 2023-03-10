using Shell.Bases;

namespace Shell.Views.SplashScreen
{
    public class SplashScreenViewModel : ViewModelBase
    {
        #region Properties

        private double _windowTop;
        public double WindowTop
        {
            get => _windowTop;
            set => SetProperty(ref _windowTop, value);
        }

        private double _windowLeft;
        public double WindowLeft
        {
            get => _windowLeft;
            set => SetProperty(ref _windowLeft, value);
        }

        private double _windowWidth;
        public double WindowWidth
        {
            get => _windowWidth;
            set => SetProperty(ref _windowWidth, value);
        }

        private double _windowHeight;
        public double WindowHeight
        {
            get => _windowHeight;
            set => SetProperty(ref _windowHeight, value);
        }

        #endregion //Properties

        #region Constructors

        public SplashScreenViewModel()
        {
            WindowTop = 300;
            WindowLeft = 300;
            WindowWidth = 150;
            WindowHeight = 150;
        }

        #endregion //Constructors
    }
}
