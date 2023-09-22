using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Input;
using Warehouse.Commands.LoginCommand;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel(Window window) : base(window)
        {
            LoginModel = new LoginModel();
            Login = new LoginCommand(this);
        }

        private LoginModel loginModel;

        public LoginModel LoginModel
        { get { return loginModel; }
            set
            {
                loginModel = value;
                this.NotifyChange(nameof(LoginModel.Password));
            }
        }
        public ICommand Login { get; set; }

        private Visibility errorVisibility;
        public Visibility ErrorVisibility
        {
            get
            { return errorVisibility; }
            set
            {
                errorVisibility = value;
                this.NotifyChange(nameof(ErrorVisibility));
            }
        }
    }
}
