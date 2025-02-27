using Serilog;

namespace Infrastructure.Common
{
    public static class StaticLogger
    {
        public static void EnsureLoggerIsInitialized()
        {
            if (Log.Logger is not Serilog.Core.Logger)
            {
                Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Console() // By default we only log to the console
                    .CreateLogger();
            }
        }
    }
}
