using System.Windows;
using System.Windows.Input;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginViewModel(Window window) : base(window)
        {

        }

        public LoginModel LoginModel { get; set; }
        public ICommand Login { get; set; }
    }
}
