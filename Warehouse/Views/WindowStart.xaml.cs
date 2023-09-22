using System.Windows;

namespace Warehouse.Views
{
    /// <summary>
    /// Interaction logic for WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        public WindowStart()
        {
            InitializeComponent();
        }


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            CheckServer();
        }

        public void CheckServer()
        {
            if (ApplicationContext.DB.IsOnline())
            {
                LoginWindow window = new LoginWindow();
                window.DataContext = new ViewModels.LoginWindowViewModel(window);
                window.Show();
                this.Close();
                return;
            }
            ConfigurationWindow configurationWIndow = new ConfigurationWindow();
            configurationWIndow.Show();
            this.Close();
        }
    }
}
