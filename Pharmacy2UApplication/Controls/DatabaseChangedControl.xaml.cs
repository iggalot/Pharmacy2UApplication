
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
            // Tell the monitor that the message has been acknowledge
            IoC.Get<ApplicationViewModel>().DatabaseMonitor.DBHasChanged = false;

            // Change the Acknowledge value
            IoC.Get<ApplicationViewModel>().DatabaseMonitor.DoAcknowledge();

            // Close off the popup-window
            IoC.Get<ApplicationViewModel>().PopupAlertWindow.SetPopupWindowVisible(false);

            //// Change the page to the New Orders Page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.OrderInformationPage);

        }
    }
}
