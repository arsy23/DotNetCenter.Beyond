namespace DotNetCenter.Beyond.Web.Core.Middlewares
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class DefaultRazorpagesMiddlewareExtension
    {
        public static IApplicationBuilder UseWeb(this IApplicationBuilder app, SupportPreConfiguration preConfiguration)
        {
            var env = preConfiguration.WebHosting;
            app.UseStopWatchMiddleware(preConfiguration);

            app.UseExceptionMiddleware(env);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });

            return app;
        }
    }
}
