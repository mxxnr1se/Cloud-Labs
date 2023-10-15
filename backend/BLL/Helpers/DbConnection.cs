using BLL.Exceptions;
using MySql.Data.MySqlClient;

namespace BLL.Helpers;

public class DbConnection
{
    /// <summary>
    ///     Checks connection string and tries to access db
    /// </summary>
    /// <returns>Connection String</returns>
    public static string GetMySqlConnection()
    {
        string? conString = Environment.GetEnvironmentVariable("ConnectionString");
        try
        {
            if (conString == null)
                throw new InvalidConStringException("Invalid connection string");

            using (var con = new MySqlConnection(conString))
            {
                con.Open();
                return conString;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}