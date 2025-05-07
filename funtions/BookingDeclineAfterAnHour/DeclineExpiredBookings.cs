using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace BookingDeclineAfterAnHour
{
    public class DeclineExpiredBookings
    {
        private readonly ILogger _logger;

        public DeclineExpiredBookings(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DeclineExpiredBookings>();
        }

        [Function("DeclineExpiredBookings")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Bookings SET Status_Value = 3 WHERE Status_Value = 1 AND CreatedAt < @ExpiryTime";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ExpiryTime", DateTime.UtcNow.AddHours(-1));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    _logger.LogInformation($"Declined {rowsAffected} expired bookings.");
                }
            }
        }
    }
}
