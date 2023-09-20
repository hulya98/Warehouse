using System;
using System.Windows;

namespace Warehouse.ViewModels
{
    public class BaseWindowViewModel
    {
        public BaseWindowViewModel(Window window)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
        }
        public Window Window { get; set; }
    }
}
