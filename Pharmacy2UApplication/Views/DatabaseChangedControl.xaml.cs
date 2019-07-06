
using System.Windows.Controls;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for DatabaseChangedControl.xaml
    /// </summary>
    public partial class DatabaseChangedControl : UserControl
    {
        //public string AcknowledgeMessage {
        //    get
        //    {
        //        string str = "";
        //        str = $"{MainWindow.DatabaseMonitor.DBConnection.DBTitle}";
        //        return str;
        //    }
        //}

        public DatabaseChangedControl()
        {
            InitializeComponent();
        }

        private void AcknowledgeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.DatabaseMonitor.DBHasChanged = false;
        }
    }
}
