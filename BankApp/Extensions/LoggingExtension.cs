using Serilog;

namespace BankApp.Extensions
{
    public static class LoggingExtension
    {
        public static void AddLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog();
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                using (StreamWriter sw = File.AppendText("Logs/LOG.TXT"))
                {
                    sw.WriteLine(msg);
                }
            });
        }
    }
}
