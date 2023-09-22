using System.Windows;
using System.Windows.Input;
using Warehouse.Commands.RegisterCommands;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class RegisterWindowViewModel : BaseWindowViewModel
    {
        public RegisterWindowViewModel(Window window) : base(window)
        {
            Register = new RegisterCommand(this);
        }

        //RegisterModel = RegisterModel();

        public RegisterModel RegisterModel { get; set; }
        public ICommand Register { get; set; }
    }
}
