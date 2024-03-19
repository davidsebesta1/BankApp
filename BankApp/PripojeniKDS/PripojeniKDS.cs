using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace propojeniSDS
{
    public class PripojeniKDS
    {
        private string connectionS;
        private static PripojeniKDS pripojeni;
        public static PripojeniKDS Pripojeni
        {
            get
            {
                if (pripojeni == null)
                {
                    pripojeni = new PripojeniKDS();
                }
                return pripojeni;
            }
        }

       
        private PripojeniKDS()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();

            connectionStringBuilder.DataSource = ConfigurationManager.AppSettings["Server"];
            connectionStringBuilder.InitialCatalog = ConfigurationManager.AppSettings["Database"];
            connectionStringBuilder.UserID = ConfigurationManager.AppSettings["User"];
            connectionStringBuilder.Password = ConfigurationManager.AppSettings["Password"];

            connectionS = connectionStringBuilder.ConnectionString;
        }
        
        public string GetConnectionString()
        {
            return connectionS;
        }

    
        #region Queries Methods
        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionS))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }


        
        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionS))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
 
        public int ExecuteScalarInt(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionS))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int intValue))
                        {
                            return intValue;
                        }

                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }


        #endregion
    }
}
