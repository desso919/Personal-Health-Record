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

namespace Personal.Health.Record.Views
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void ViewProfile(object sender, RoutedEventArgs e)
        {
            PatientDetails patientDetails = new PatientDetails();
            this.NavigationService.Navigate(patientDetails);

        }

        private void ViewHospitals(object sender, RoutedEventArgs e)
        {
            HospitalsPage hospitals = new HospitalsPage();
            this.NavigationService.Navigate(hospitals);

        }

        private void ViewDoctors(object sender, RoutedEventArgs e)
        {
            DoctorsPage doctors = new DoctorsPage();
            this.NavigationService.Navigate(doctors);
        }

        private void ViewHistory(object sender, RoutedEventArgs e)
        {
            PatientHistoryPage patientHistoryPage = new PatientHistoryPage();
            this.NavigationService.Navigate(patientHistoryPage);
        }

        private void ViewScheduledVisitations(object sender, RoutedEventArgs e)
        {
            ScheduledVisitationsPage scheduledVisitationsPage = new ScheduledVisitationsPage();
            this.NavigationService.Navigate(scheduledVisitationsPage);
        }

        private void CreateNewVisitation(object sender, RoutedEventArgs e)
        {
            SchedulingVisitationPage schedulingVisitationPage = new SchedulingVisitationPage();
            this.NavigationService.Navigate(schedulingVisitationPage);
        }

        private void AddHistory(object sender, RoutedEventArgs e)
        {
            AddHistoryPaga addHistoryPaga = new AddHistoryPaga();
            this.NavigationService.Navigate(addHistoryPaga);
        }
    }
}
