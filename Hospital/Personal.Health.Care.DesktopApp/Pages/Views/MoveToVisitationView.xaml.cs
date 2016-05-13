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

namespace Personal.Health.Care.DesktopApp.Pages.Views
{
    /// <summary>
    /// Interaction logic for MoveToVisitationView.xaml
    /// </summary>
    public partial class MoveToVisitationView : ModernDialog
    {
        public MoveToVisitationView()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }
    }
}
