using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal.Health.Care.DesktopApp.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : ModernWindow
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView reg = new RegistrationView();
            this.Close();
            reg.Show();
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    MainWindow reg = new MainWindow();
        //    this.Close();
        //    reg.Show();

        //}
    }
}
