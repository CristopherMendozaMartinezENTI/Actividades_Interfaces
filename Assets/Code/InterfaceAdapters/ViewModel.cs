using System;
using System.Collections.Generic;

namespace Code.InterfaceAdapters
{
    public abstract class ViewModel : IDisposable
    {
        protected List<IDisposable> _disposables = new List<IDisposable>();
    
        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}