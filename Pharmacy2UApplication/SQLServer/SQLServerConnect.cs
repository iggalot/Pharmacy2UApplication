
using System;
using System.Data.SqlClient;
using System.Windows;

namespace Pharmacy2UApplication
{
    public class SQLServerConnect
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SQLServerConnect()
        {
            MessageBox.Show("Making new Connection");
        }

        /// <summary>
        /// Testing the SQL Server connectivity
        /// </summary>
        public void SQLTestConn()
        {
            Console.WriteLine("Hello World");

            // The SQL connection string required to connect to our database.  
            // As defined at "SQL Server Connection Strings" website.
            /// Server=myServerAddress;Database=myDataBase;User Id=myUsername; Password = myPassword;
            /// myserverAddress = .  -- for this machine
            /// myDataBase = dbo.test -- the database to connect to on the server
            /// myUsername = sa -- the login to the sql server
            /// myPassword = sqlserver -- the password to the database
            using (var sqlConnection = new SqlConnection("Server = .; Database = test; User Id = sa; Password = sqlserver;"))
            {
                // Open the SQL connection
                sqlConnection.Open();

                //// For Writing a record:  The command to execute on our SQL server
                //using (var command = new SqlCommand($"INSERT INTO dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Username1', 'My first name', 'My last name', 1, '2/28/19 1:45:00 AM -08:00' )", sqlConnection))
                //{
                //    // Read the database results that are returned
                //    var result = command.ExecuteNonQuery();
                //}

                // For Reading a record:  The command to execute on our SQL server
                using (var command = new SqlCommand("SELECT * FROM dbo.Users", sqlConnection))
                {
                    // Read the database results that are returned
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Username: {reader["Username"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, IsEnabled: {reader["IsEnabled"]}");
                        }
                    }
                }
            }

        }
    } 
}
 