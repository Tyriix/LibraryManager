using System.ComponentModel;

namespace LibraryManager.WPF.Models
{
    /// <summary>
    /// This is a base class for objects that are observable.
    /// It's used to support objects that need property change notification.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
