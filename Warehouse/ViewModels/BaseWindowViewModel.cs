using System;
using System.ComponentModel;
using System.Windows;

namespace Warehouse.ViewModels
{
    public class BaseWindowViewModel : INotifyPropertyChanged
    {
        public BaseWindowViewModel(Window window)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }
        public Window Window { get; set; }

        public event  PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyChange(String name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
