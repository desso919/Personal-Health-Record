using FirstFloor.ModernUI.Windows.Controls;
using Personal.Health.Care.DesktopApp.Model;
using Personal.Health.Care.DesktopApp.ViewModels;
using Personal.Health.Models;
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
    /// Interaction logic for TemplateEdit.xaml
    /// </summary>
    public partial class TemplateEdit : ModernDialog
    {
        public TemplateEdit()
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton };
        }

        public TemplateEdit(Template template)
        {
            InitializeComponent();

            // define the dialog buttons
            this.Buttons = new Button[] { this.OkButton, this.CancelButton };
            this.DataContext = new EditTemplateViewModel(template);
            this.OkButton.Command = MediatorClass.SaveTemplateCommand;
        }




    }
}
