using Shell.Bases;

namespace Shell.Views.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        private string _applicationTitle;
        public string ApplicationTitle
        {
            get => _applicationTitle;
            private set => SetProperty(ref _applicationTitle, value);
        }

        #endregion //Properties

        #region Constructors

        public MainWindowViewModel()
        {
            _applicationTitle = "My application";
        }

        #endregion //Constructors
    }
}
