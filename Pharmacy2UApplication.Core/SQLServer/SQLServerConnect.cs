
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Input;

namespace Pharmacy2UApplication.Core
{
    /// <summary>
    /// A class that controls the connection to a specified database
    /// </summary>
    public class SQLServerConnect
    {
        #region Public Members

        // A list of our command history for this connection.
        public static ObservableCollection<string> History { get; set; }

        /// <summary>
        /// The name of this database
        /// </summary>
        public static string DBTitle { get; set; }

        #endregion

        #region Database Relay Commands

        // Our command to create and populate a default database
        public ICommand DBCreateCommand { get; set; }

        //TODO: Add a security check for the CLEAR command
        // Our command to clear and empty the default database
        public ICommand DBClearCommand { get; set; }

        // Our command to display the contents of the default database
        public ICommand DBDisplayCommand { get; set; }

        // Our command to add a single record to our test database
        public ICommand DBAddSingleRecord { get; set; }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SQLServerConnect(string title)
        {
            string cmd = "";
            // Create our database history
            History = new ObservableCollection<string>();

            // Store our database table name
            DBTitle = title;

            // Add messages to History of this server connection
            cmd = $"Creating connection to database: {DBTitle}.db ";
            History.Add(cmd);
            Console.WriteLine(cmd);

            // Create commands to create, display and delete the database via XAML controls.
            cmd = $"-- Creating database relay commands";
            Console.WriteLine(cmd);
            History.Add(cmd);

            DBCreateCommand = new RelayCommand(() => this.CreateDB());
            DBClearCommand = new RelayCommand(() => this.ClearDB());
            DBDisplayCommand = new RelayCommand(() => this.DisplayDB());
            DBAddSingleRecord = new RelayCommand(() => this.AddSingleRecordToTest());
        }

        #endregion

        #region Private Database Utility Methods

        /// <summary>
        /// A command to display the contents of our test database.
        /// </summary>
        private void DisplayDB()
        {
            int recordCount = 0;
            string cmd = "";

            cmd = "-------------------------------------";
            Console.WriteLine(cmd);
            History.Add(cmd);

            cmd = "----Displaying all database objects";
            Console.WriteLine(cmd);
            History.Add(cmd);

            // The SQL connection string required to connect to our database.  
            // As defined at "SQL Server Connection Strings" website.
            /// Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password = myPassword;
            /// myserverAddress = .  -- for this machine
            /// myDataBase = dbo.test -- the database to connect to on the server
            /// myUsername = sa -- the login to the sql server
            /// myPassword = sqlserver -- the password to the database
            using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
            {
                try
                {
                    // Open the SQL connection
                    sqlConnection.Open();

                    // For Reading a record:  The command to execute on our SQL server
                    cmd = "SELECT * FROM dbo.Users";
                    History.Add(cmd);

                    using (var command = new SqlCommand(cmd, sqlConnection))
                    {
                        // Read the database results that are returned
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // writing out our database results
                                cmd = $"Username: {reader["Username"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, IsEnabled: {reader["IsEnabled"]}, CreatedDateUtc: {reader["CreatedDateUtc"]}";
                                History.Add(cmd);
                                Console.WriteLine(cmd);
                                recordCount++;
                            }
                        }
                    }
                } catch
                {
                    cmd = "Error Opening database";
                    History.Add(cmd);
                    //MessageBox.Show(cmd);
                } finally { 
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }

            cmd = $"---- Displaying {recordCount.ToString()} records";
            History.Add(cmd);
            Console.WriteLine(cmd);

            for(int i=0; i<History.Count; i++)
            {
                Console.WriteLine($"{i} -- '{History[i]}");
            }
        }

        /// <summary>
        /// A database command that deletes all of the contents of our test table.
        /// </summary>
        private void ClearDB()
        {
            string cmd = "";

            cmd = "-------------------------------------";
            History.Add(cmd);
            Console.WriteLine("-------------------------------------");

            cmd = "---- Deleting database objects";
            History.Add(cmd);
            Console.WriteLine("---- Deleting database objects");

            // The SQL connection string required to connect to our database.  
            // As defined at "SQL Server Connection Strings" website.
            /// Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password = myPassword;
            /// myserverAddress = .  -- for this machine
            /// myDataBase = dbo.test -- the database to connect to on the server
            /// myUsername = sa -- the login to the sql server
            /// myPassword = sqlserver -- the password to the database
            using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
            {
                try
                {
                    // Open the SQL connection
                    sqlConnection.Open();

                    // For deleting all records from the database:  The command to execute on our SQL server
                    cmd = "DELETE FROM dbo.Users";
                    using (var command = new SqlCommand(cmd, sqlConnection))
                    {
                        History.Add(cmd);
                        // Read the database results that are returned
                        int reader = command.ExecuteNonQuery();

                        cmd = $"---- { reader.ToString()} records deleted from database";
                        History.Add(cmd);
                        Console.WriteLine(cmd);
                    }
                } catch
                {
                    cmd = "Error Opening database";
                    History.Add(cmd);
                    //MessageBox.Show(cmd);
                }
                finally
                {
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Creating data for our test database
        /// </summary>
        private void CreateDB()
        {
            string cmd = "";

            cmd = "-------------------------------------";
            History.Add(cmd);
            Console.WriteLine("-------------------------------------");

            cmd = "---- Creating database objects";
            History.Add(cmd);
            Console.WriteLine("---- Creating database objects");

            // The SQL connection string required to connect to our database.  
            // As defined at "SQL Server Connection Strings" website.
            /// Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password = myPassword;
            /// myserverAddress = .  -- for this machine
            /// myDataBase = dbo.test -- the database to connect to on the server
            /// myUsername = sa -- the login to the sql server
            /// myPassword = sqlserver -- the password to the database
            using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
            {
                try
                {
                    // Open the SQL connection
                    sqlConnection.Open();
                    int recordCount = 0;

                    // For Writing a record:  The command to execute on our SQL server
                    cmd = $"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Jim', 'Jim', 'Allen', 1, '2/28/19 1:45:00 AM -08:00' )";
                    AddSingleRecordToDB("dbo.Users", cmd, sqlConnection);
                    recordCount++;

                    cmd = $"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Kira123', 'Kira', 'Lukilu', 1, '2/28/19 1:45:00 AM -08:00' )";
                    // For Writing a record:  The command to execute on our SQL server
                    AddSingleRecordToDB("dbo.Users", cmd, sqlConnection);
                    recordCount++;

                    // For Writing a record:  The command to execute on our SQL server
                    cmd = $"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Olaf123', 'Olaf', 'von Owenson', 1, '2/28/19 1:45:00 AM -08:00' )";
                    AddSingleRecordToDB("dbo.Users", cmd, sqlConnection);
                    recordCount++;

                    // For Writing a record:  The command to execute on our SQL server
                    cmd = $"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Leslie123', 'Leslie', 'Retriever', 1, '2/28/19 1:45:00 AM -08:00' )";
                    AddSingleRecordToDB("dbo.Users", cmd, sqlConnection);
                    recordCount++;
                }
                catch
                {
                    cmd = "Error Opening database";
                    History.Add(cmd);
                    //MessageBox.Show(cmd);
                }
                finally
                {
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }

        }

        /// <summary>
        /// Helper function to add a single record to the database.  Updates the History for the database history feature.
        /// </summary>
        /// <param name="dbtablename">The name of the database table</param>
        /// <param name="sqlcommand">The SQL command to pass to the server</param>
        /// <param name="connection">The SQLConnection to the specific table in the server</param>
        public void AddSingleRecordToDB(string dbtablename, string sqlcommand, SqlConnection connection)
        {
            // For Writing a record:  The command to execute on our SQL server
            using (var command = new SqlCommand(sqlcommand, connection))
            {
                History.Add(sqlcommand);
                // Read the database results that are returned
                var result = command.ExecuteNonQuery();
            }

            string cmd = $"---- 1 record added to the database";
            History.Add(cmd);
            Console.WriteLine(cmd);
        }

        // Adds a single record to the test database
        public void AddSingleRecordToTest()
        {
            using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
            {
                string cmd = "";
                try
                {
                    // Open the SQL connection
                    sqlConnection.Open();
                    // get the current time in UTC format for injecting into our test record.
                    DateTime nowTimeUTC = DateTime.Now;

                    // For Writing a record:  The command to execute on our SQL server
                    cmd = $"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Leslie123', 'Leslie', 'Retriever', 1, '{nowTimeUTC.ToString()}' )";
                    AddSingleRecordToDB("dbo.Users", cmd, sqlConnection);
                }
                catch
                {
                    cmd = "Error Opening database";
                    History.Add(cmd);
                    //MessageBox.Show(cmd);
                }
                finally
                {
                    // close the server connection
                    sqlConnection.Close();
                }
            }
        }

        #endregion
    } 
}
 