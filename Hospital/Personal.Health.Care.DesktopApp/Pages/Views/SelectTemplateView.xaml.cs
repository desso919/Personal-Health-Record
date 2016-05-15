﻿using FirstFloor.ModernUI.Windows.Controls;
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
    /// Interaction logic for SelectTemplateView.xaml
    /// </summary>
    public partial class SelectTemplateView : ModernWindow
    {
        public SelectTemplateView()
        {
            InitializeComponent();
            this.DataContext = TemplatesViewModel.GetInstance();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
