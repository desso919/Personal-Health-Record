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
    /// Interaction logic for AskDiagnoseView.xaml
    /// </summary>
    public partial class AskDiagnoseView : ModernDialog
    {
        public AskDiagnoseView()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.OkButton.Command = MediatorClass.OKCommand;
        }


        public AskDiagnoseView(ScheduledVisitation visit)
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.DataContext = new AskDiagnoseViewModel(visit);
            this.OkButton.Command = MediatorClass.OKCommand;
        }

        public string ResponseText
        {
            get { return ResponseTextBox.Text; }
            set { ResponseTextBox.Text = value; MediatorClass.diagnose = value; }
        } 
    }
}
