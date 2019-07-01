
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Pharmacy2UApplication
{
    public class SQLServerConnect
    {
        #region Database Relay Commands

        // Our command to create and populate a default database
        public ICommand DBCreateCommand { get; set; }

        //TODO: Add a security check for the CLEAR command
        // Our command to clear and empty the default database
        public ICommand DBClearCommand { get; set; }

        // Our command to display the contents of the default database
        public ICommand DBDisplayCommand { get; set; }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SQLServerConnect()
        {
            Console.WriteLine("Creating connection to database...");
            //MessageBox.Show("Making new Connection");

            // Create commands to create, display and delete the database via XAML controls.
            Console.WriteLine("-- Creating database database commands");
            DBCreateCommand = new RelayCommand(() => this.CreateDB());
            DBClearCommand = new RelayCommand(() => this.ClearDB());
            DBDisplayCommand = new RelayCommand(() => this.DisplayDB());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// A command to display the contents of our database.
        /// </summary>
        private void DisplayDB()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("----Displaying all database objects");
            int recordCount = 0;
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
                    using (var command = new SqlCommand("SELECT * FROM dbo.Users", sqlConnection))
                    {
                        // Read the database results that are returned
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // writing out our database results
                                Console.WriteLine($"Username: {reader["Username"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, IsEnabled: {reader["IsEnabled"]}");
                                recordCount++;
                            }
                        }
                    }
                } catch
                {
                    MessageBox.Show("Error Opening database");
                } finally { 
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }

            Console.WriteLine("---- Displaying " + recordCount.ToString() + " records");
        }

        /// <summary>
        /// A database command that deletes all of the contents of a specified table.
        /// </summary>
        private void ClearDB()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("----Deleting database objects");

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
                    using (var command = new SqlCommand("DELETE FROM dbo.Users", sqlConnection))
                    {
                        // Read the database results that are returned
                        int reader = command.ExecuteNonQuery();

                        Console.WriteLine("---- " + reader.ToString() + " records deleted from database");
                    }
                } catch
                {
                    MessageBox.Show("Error Opening database");
                }
                finally
                {
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Creating data for our test database connectivity
        /// </summary>
        private void CreateDB()
        {
            Console.WriteLine("-------------------------------------");
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
                    using (var command = new SqlCommand($"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Jim', 'Jim', 'Allen', 1, '2/28/19 1:45:00 AM -08:00' )", sqlConnection))
                    {
                        // Read the database results that are returned
                        var result = command.ExecuteNonQuery();
                        recordCount++;
                    }
                    // For Writing a record:  The command to execute on our SQL server
                    using (var command = new SqlCommand($"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Kira123', 'Kira', 'Lukilu', 1, '2/28/19 1:45:00 AM -08:00' )", sqlConnection))
                    {
                        // Read the database results that are returned
                        var result = command.ExecuteNonQuery();
                        recordCount++;
                    }
                    // For Writing a record:  The command to execute on our SQL server
                    using (var command = new SqlCommand($"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Olaf123', 'Olaf', 'von Owenson', 1, '2/28/19 1:45:00 AM -08:00' )", sqlConnection))
                    {
                        // Read the database results that are returned
                        var result = command.ExecuteNonQuery();
                        recordCount++;
                    }
                    // For Writing a record:  The command to execute on our SQL server
                    using (var command = new SqlCommand($"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Leslie123', 'Leslie', 'Retriever', 1, '2/28/19 1:45:00 AM -08:00' )", sqlConnection))
                    {
                        // Read the database results that are returned
                        var result = command.ExecuteNonQuery();
                        recordCount++;
                    }

                    Console.WriteLine("---- " + recordCount.ToString() + " records added to the database");
                }
                catch
                {
                    MessageBox.Show("Error Opening database");
                }
                finally
                {
                    //Close the SQL connection
                    sqlConnection.Close();
                }
            }

        }

        #endregion

    } 
}
 