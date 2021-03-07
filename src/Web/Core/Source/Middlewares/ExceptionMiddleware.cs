namespace DotNetCenter.Beyond.Web.Core.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
    public static class ExceptionMiddleware
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error", "?scode={0}");
                app.UseExceptionHandler("/Error");
            }

            return app;
        }
    }
}
