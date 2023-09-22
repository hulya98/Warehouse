  using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse.Core.Domain.Entities;
using Warehouse.Utils;
using Warehouse.ViewModels;
using Warehouse.Views;

namespace Warehouse.Commands.RegisterCommands
{
    public class RegisterCommand :ICommand
    {
        public readonly RegisterWindowViewModel _windowViewModel;

        public RegisterCommand(RegisterWindowViewModel windowViewModel)
        {
            _windowViewModel = windowViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute (object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string password  = ((PasswordBox)parameter).Password;
            User user = new User
            {
                UserName = _windowViewModel.RegisterModel.UserName,
                Email = _windowViewModel.RegisterModel.Email,
                PasswordHash = HashHelper.Hash(password),
            };

            ApplicationContext.DB.UserRepository.Add(user);
            LoginWindow window = new LoginWindow();
            window.DataContext = new LoginWindowViewModel(window);

            window.Show();
            _windowViewModel.Window.Close();

        }
    }
}
