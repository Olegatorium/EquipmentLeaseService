using Microsoft.Data.SqlClient;

namespace EquipmentLeaseService.API.Middleware
{
    public static class DatabaseWarmUp
    {
        public static async Task WarmUpDatabaseAsync(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT 1", connection);
                    await command.ExecuteNonQueryAsync();
                }
                Console.WriteLine("The database has been successfully warmed up.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The database is still warming up.");
            }
        }
    }
}
