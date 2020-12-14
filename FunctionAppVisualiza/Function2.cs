using System;
using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppVisualiza
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static void Run([QueueTrigger("update-data-queue", Connection = "AzureWebJobsStorage")]Jogo jogo, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed."); // mensagem myqueue//

            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var textSql = $@"UPDATE [dbo].[Jogo] SET [DataNascimento] = GETDATE() WHERE [Id] = {jogo.Id};";

                using (SqlCommand cmd = new SqlCommand(textSql, conn))
                {
                    var rowsAffected = cmd.ExecuteNonQuery();
                    log.LogInformation($"rowsAffected: {rowsAffected}");
                }
            }

        }
    }

    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
