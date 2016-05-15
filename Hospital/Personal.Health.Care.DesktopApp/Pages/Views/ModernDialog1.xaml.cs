using FirstFloor.ModernUI.Windows.Controls;
using Hospital.Models;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Care.DesktopApp.ViewModels;
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
    /// Interaction logic for ModernDialog1.xaml
    /// </summary>
    public partial class ModernDialog1 : ModernDialog
    {
        public ModernDialog1()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
        }

        public ModernDialog1(ScheduledVisitation visitation)
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };            
            this.DataContext = new EditVisitationViewModel(visitation);
            this.OkButton.Command = MediatorClass.SaveCommand;            
        }
    }
}
