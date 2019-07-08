
using System.Windows.Controls;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for DatabaseChangedControl.xaml
    /// </summary>
    public partial class DatabaseChangedControl : UserControl
    {
        public DatabaseChangedControl()
        {
            InitializeComponent();
        }

        private void AcknowledgeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.DatabaseMonitor.DBHasChanged = false;

            // Change the page to the New Orders Page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.OrderInformationPage);

        }
    }
}
