namespace TestTask.Controllers.Configutation
{
    public static class LoggingConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Information);
        }
    }
}