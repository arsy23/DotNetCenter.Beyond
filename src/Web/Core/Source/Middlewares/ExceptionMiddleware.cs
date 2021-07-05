namespace DotNetCenter.Beyond.Web.Core.Middlewares
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;

    public static class ExceptionMiddleware
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app, SupportWebHosting env)
        {
            if (env.Service.IsDevelopment())
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
