using System;
using System.Runtime;
namespace _01.TestIDisposable
{
    internal class MyClassDisposable : IDisposable
    {
        private bool IsDisposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this);
        }
        protected void Dispose(bool Diposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                { // zwalniaj zasoby zarządzalne }
                  // zwalniaj zasoby niezarządzalne
                }
                IsDisposed = true;
            }

            ~MyClassDisposable()
            {
                Dispose(false);
            }

        }
    }
}