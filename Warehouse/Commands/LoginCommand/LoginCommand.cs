using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Warehouse.ViewModels;

namespace Warehouse.Commands.LoginCommand
{
    public class LoginCommand :ICommand
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;

        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel ?? throw new ArgumentNullException(nameof(loginWindowViewModel));
        }

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter) 
        {
            const string defaultUserName = "admin";
            const string defaultPassword = "12345"; 
            string username = _loginWindowViewModel.LoginModel.Username;
            String password = ((PasswordBox)parameter).Password;
            if(username == defaultUserName && password == defaultPassword)
            {
                MessageBox.Show("logged in...");
                return;
            }

            _loginWindowViewModel.LoginModel.Password = string.Empty;
            _loginWindowViewModel.ErrorVisibility = Visibility.Visible;

        }
    }
}
