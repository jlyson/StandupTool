using Prism.Mvvm;
using System;

namespace Shell.Bases
{
    public class ViewModelBase : BindableBase, IDisposable
    {
        #region Properties

        public bool IsDisposed { get; private set; }

        #endregion //Properties

        #region Public methods

        public void Dispose()
        {
            if (IsDisposed)
                return;

            Dispose(true);
            GC.SuppressFinalize(this);
            IsDisposed = true;
        }

        #endregion //Public methods

        #region Override methods

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion //Override methods

    }
}
