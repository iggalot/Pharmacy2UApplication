
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Public Accessors
        // Our sql connection view model
        public static SQLServerConnect SQLServerConnection { get; set; }

        // Our database monitor apparatus
        public static DBMonitor DatabaseMonitor { get; set; }

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // Testing of our C# to SQL connectivity
            SQLServerConnection = new SQLServerConnect("test");

            // Our DatabaseMonitor System for tracking when a database has changed
            DatabaseMonitor = new DBMonitor(SQLServerConnection);

            // Set the data context for the XAML Bindings in the GUI
            DataContext = this;
        }
    }
}
