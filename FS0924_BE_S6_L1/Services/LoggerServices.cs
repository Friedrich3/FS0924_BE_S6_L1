using Serilog;

namespace FS0924_BE_S6_L1.Services
{
    public class LoggerServices
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

        }

        public void LogInfo(string message)
        {
            Log.Information(message);
        }
        public void LogError(string message)
        { 
            Log.Error(message);
        }


    }
}
