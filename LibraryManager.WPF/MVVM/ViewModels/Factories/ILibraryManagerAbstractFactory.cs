using LibraryManager.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public interface ILibraryManagerAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
