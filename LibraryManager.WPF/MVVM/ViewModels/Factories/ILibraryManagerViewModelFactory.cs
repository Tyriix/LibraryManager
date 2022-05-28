using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public interface ILibraryManagerViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
