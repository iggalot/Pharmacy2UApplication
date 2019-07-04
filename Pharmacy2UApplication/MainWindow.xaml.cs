
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Private Members

        // stores the state of the database scan
        private bool dbHasChanged;

        #endregion

        #region Public Accessors
        // Our sql connection view model
        public SQLServerConnect SQLServerConnection {get; set;}

        // The thread that will monitor the database for activity
        public Thread monitorThread { get; set; }

        // Boolean to signify that the database has changed
        public bool DBHasChanged
        {
            get { return dbHasChanged; }
            set
            {
                if (dbHasChanged != value)
                {
                    // set the value and notify that the property has changed
                    dbHasChanged = value;

                    // notify that our property has changed
                    OnPropertyChanged("DBHasChanged");
                }      
            }
        }

        // The number of records in the test database, used for monitoring activity;
        public int numRecords { get; set; }

        // A number of records to compare activity against for our monitor
        public int lastCount { get; set; } = 3;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // Testing of our C# to SQL connectivity
            SQLServerConnection = new SQLServerConnect("test");

            // Set the data context for the XAML Bindings in the GUI
            DataContext = this;

            //// Spin off a thread to handle the monitoring of the database
            monitorThread = new Thread(MonitorDB);
            monitorThread.Start();

        }


        // The action to be used by the thread that monitors the database for changes in activity
        private void MonitorDB()
        {
            int loop = 0;
            while (true)
            {
                // wait before scanning the database
                Thread.Sleep(1000);
                loop++;
               
                using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
                {
                    try
                    {
                        // Open the SQL connection
                        sqlConnection.Open();

                        // For Reading a record:  The command to execute on our SQL server
                        string cmd = "SELECT COUNT(*) FROM dbo.Users";
                        Console.WriteLine(cmd);

                        using (var command = new SqlCommand(cmd, sqlConnection))
                        {
                            // Read the database results that are returned
                            int count = (Int32)command.ExecuteScalar();
                            cmd = $"{loop.ToString()}: {count.ToString()} records found this cycle";
                            Console.WriteLine(cmd);

                            if (count > lastCount)
                            {
                                DBHasChanged = true;
                            }

                            //TODO add functionality to switch the DBHasChanged criteria back
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error opening the database in the monitoring thread");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

        // Defining the function that creates the PropertyChanged Event
        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        // THe interface implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
    }


}
