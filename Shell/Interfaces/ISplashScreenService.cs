namespace Shell.Interfaces
{
    /// <summary>
    /// Service that handles splash screen of the application
    /// </summary>
    public interface ISplashScreenService
    {
        #region Public methods

        /// <summary>
        /// Opens the splash screen window or ignores if already open
        /// </summary>
        void OpenSplashScreen();

        /// <summary>
        /// Closes the splash screen window or ignores if already closed
        /// </summary>
        void CloseSplashScreen();

        #endregion //Public methods

    }
}
