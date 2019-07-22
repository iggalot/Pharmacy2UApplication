
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
    public class DBMonitor : INotifyPropertyChanged
    {
        #region Private Members

        // stores the state of the database scan
        private bool dbHasChanged;

        // stores the quantity changed since last time it was acknowledge
        private int mChangeSinceLastAcknowledge;

        // The monitor thread loop time in milliseconds
        private int ThreadLoopTimeMilliSeconds = 3500;

        #endregion

        #region Public Members

        // The thread that will monitor the database for activity
        public Thread MonitorThread { get; set; }

        // The SQL Server connection that the monitor utilizes
        public SQLServerConnect DBConnection { get; set; }

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
                    OnPropertyChanged(nameof(DBHasChanged));
                }
            }
        }

        // The number of records in the test database, used for monitoring activity;
        public static int NumRecords { get; set; } = 0;

        // A number of records to compare activity against for our monitor
        public static int LastAcknowledge { get; set; } = 0;

        // Computes the changes since the last time the count was acknowledge
        public int ChangeSinceLastAcknowledgeProperty
        {
            get { return mChangeSinceLastAcknowledge; }
            set
            {
                if (mChangeSinceLastAcknowledge != value)
                {
                    // set the value and notify that the property has changed
                    mChangeSinceLastAcknowledge = value;

                    // notify that our property has changed
                    OnPropertyChanged(nameof(ChangeSinceLastAcknowledgeProperty));
                }
            }
        } 

        #endregion

        #region Default Constructor

        public DBMonitor(SQLServerConnect connection)
        {
            // Save our connection
            DBConnection = connection;

            // Signify nothing has changed from initial startup
            DBHasChanged = false;

            // Create our Relay commands
            ResetAcknowledgeCount = new RelayCommand(() => ResetAcknowledge());

            //// Spin off a thread to handle the monitoring of the database
            MonitorThread = new Thread(MonitorDB);
            MonitorThread.Start();
        }



        #endregion

        #region Public Methods

        /// <summary>
        /// A routine that acknowledges that the changes in the popup status have been viewed
        /// </summary>
        public void DoAcknowledge()
        {
            // Sets the acknowledge amount to the same value as the number of records
            LastAcknowledge = NumRecords;

            // Signify that the database is now in a new unchanged state for the previous acknowledgement
            DBHasChanged = false;
        }

        #endregion

        #region Thread Loop

        // The action loop to be used by the thread that monitors the database for changes in activity
        private void MonitorDB()
        {
            int loop = 0;
            while (true)
            {
                // wait before scanning the database
                Thread.Sleep(ThreadLoopTimeMilliSeconds);
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
                            NumRecords = (Int32)command.ExecuteScalar();
                            cmd = $"{loop.ToString()}: {NumRecords.ToString()} records found this cycle";
                            Console.WriteLine(cmd);

                            // If the database has more records than the last cycle, signify that it has changed
                            if (NumRecords > LastAcknowledge)
                            {
                                ChangeSinceLastAcknowledgeProperty = NumRecords - LastAcknowledge;
                                DBHasChanged = true;
                            } 
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error opening the database in the monitoring thread");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }

                    // If a change has been detected, trigger the popup
                    if (DBHasChanged)
                        IoC.Get<ApplicationViewModel>().PopupAlertWindow.SetPopupWindowVisible(true);

                    // Reset the flag
                    DBHasChanged = false;
                }
            }
        }

        #endregion

        #region Event handlers

        // Defining the function that creates the PropertyChanged Event
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        // The interface implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Database Relay Commands

        // Our command to reset the Acknowledge counter
        public ICommand ResetAcknowledgeCount { get; set; }
        public object MessageBox { get; private set; }

        private void ResetAcknowledge()
        {
            LastAcknowledge = 0;

            // If the database has more records than the last cycle, signify that it has changed
            if (NumRecords > LastAcknowledge)
            {
                ChangeSinceLastAcknowledgeProperty = NumRecords - LastAcknowledge;
                DBHasChanged = true;
            }

        }

        #endregion

    }

}

