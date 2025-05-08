using Microsoft.Azure.Functions.Worker;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace BookingComplete
{
    public class BookingCompleteIfEndTimeHasPassed
    {
        private readonly ILogger _logger;

        public BookingCompleteIfEndTimeHasPassed(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BookingCompleteIfEndTimeHasPassed>();
        }

        [Function("BookingCompleteIfEndTimeHasPassed")]
        public void Run([TimerTrigger("0 */30 * * * *")] TimerInfo myTimer)
        {
            string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Bookings SET Status_Value = 6 WHERE Status_Value IN (4, 5) AND EndTime < @ExpiryTime AND EndDay <= @ExpiryTime";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var expiryTime = DateTime.UtcNow.AddMinutes(30);

                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    _logger.LogInformation($"Time now in UTC is: {DateTime.UtcNow}");
                    _logger.LogInformation($"Time passed to query is: {expiryTime}");
                    _logger.LogInformation($"Time now is: {DateTime.Now}");
                    _logger.LogInformation($"Declined {rowsAffected} expired bookings.");
                }
            }
        }
    }
}
