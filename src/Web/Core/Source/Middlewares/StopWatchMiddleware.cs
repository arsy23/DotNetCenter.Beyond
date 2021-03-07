namespace DotNetCenter.Beyond.Web.Core.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Text;

    public static class StopWatchMiddleware
    {
        public static IApplicationBuilder UseStopWatchMiddleware(
                   this IApplicationBuilder app,
                   IWebHostEnvironment env,
                   ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.Use(async (context, next) =>
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    await next.Invoke();
                    sw.Stop();
                    var logger = loggerFactory.CreateLogger(nameof(UseStopWatchMiddleware));
                    var elapsedTicks = sw.ElapsedTicks;
                    var elapsedTime = sw.ElapsedMilliseconds;
                    var elapsedTimeLabel = sw.ElapsedMilliseconds < 5000 ? $"{elapsedTime} ms" : $"{(double)(elapsedTime / 1000)} sec";
                    LogUserRequest(logger, elapsedTime, elapsedTimeLabel, elapsedTicks);
                });
            return app;
        }

        private static void LogUserRequest(ILogger logger, long elapsedTime, string elapsedTimeLabel, long elipsedTick)
        {
            var baseMessage = $"|| User Request Processed in [{elapsedTimeLabel}, {elipsedTick} thicks] throw the Pipeline --> ";
            var loggerMessageBuilder = new StringBuilder(baseMessage);
            var noPerformanceMessage = "+NO PERFORMANCE! Long running request, that is too slow.";
            var lowPerformanceMessage = "+LOW PERFORMANCE! The Request handled slowly, it is bad for users.";
            var normalPerformanceMessage = "+NORMAL PERFORMANCE! Request processing  it was normal, maybe faster at next time without any effort.";
            var highPerformanceMessage = "+HIGH PERFORMANCE! The request runtime it was excellent.";

            if (elapsedTime > 1000)
                logger.LogError(AppendLogMessage(loggerMessageBuilder, noPerformanceMessage));
            if (elapsedTime <= 1000 && elapsedTime > 500)
                logger.LogCritical(AppendLogMessage(loggerMessageBuilder, lowPerformanceMessage));
            else if (elapsedTime <= 500 && elapsedTime > 250)
                logger.LogWarning(AppendLogMessage(loggerMessageBuilder, normalPerformanceMessage));
            else if (elapsedTime <= 250 && elapsedTime > 0)
                logger.LogInformation(AppendLogMessage(loggerMessageBuilder, highPerformanceMessage));
        }
        private static string AppendLogMessage(
            StringBuilder stringBuilder,
            string message)
            => stringBuilder.Append(message).ToString();
    }
}
