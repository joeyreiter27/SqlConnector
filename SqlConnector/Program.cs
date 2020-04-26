using System;
using System.Data.SqlClient;

namespace SqlConnector
{
    class Program
    {
        static void Main(string[] args)
        {

            // text within quotes taken from connectionstrings.com
            using(var sqlConnection = new SqlConnection("Server=.;Database=Tseries Controller Database;User Id=sa;Password=Myname02!;"))
            {
                //opens the database connection
                sqlConnection.Open();




                //Inserts a new row of values into all specified columns
                // the Guid functions are used to give the value a generated unique value

                using (var command = new SqlCommand($"INSERT INTO  dbo.Users (id, Username, FirstName, LastName, IsEnabled, CreatedDateUtc) VALUES ('{Guid.NewGuid().ToString("N")}', 'Username1', 'My first name', 'My last name', 1,'12/12/2020 11:30:30 AM +00:00' )", sqlConnection))
                {
                    // Checks to ensure the insert function was executed... result = 1 means it executed
                    var result = command.ExecuteNonQuery();
                   


                }
                //used to select data from the Users database
                using (var command = new SqlCommand("SELECT * FROM dbo.Users",sqlConnection))
                {
                    //assigns the values of what is read in each cell to the variable reader 
                    // there are multiple other execute options that will give you different options for what values youll return from the table
                    using (var reader = command.ExecuteReader())
                    {
                        //creates while loop that reads and assigns each row of the table
                        while (reader.Read())
                        {
                            // writes the content of the table in a logical text statement
                            // 
                            Console.WriteLine($"Username { reader["Username"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]},IsEnabled: {reader["IsEnabled"]}");
                        }
                    }

                   
                }
            }

        }
    }
}
