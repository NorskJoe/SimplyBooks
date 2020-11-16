using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;
using System.Collections.Generic;
using System.Net;

namespace SimplyBooks.Services.ExceptionHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<SimplyBooksExceptionHandler> logger)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;
                    if (exceptionHandlerPathFeature != null)
                    {
                        var id = logger.LogErrorWithEventId(exception);
                        await context.Response.WriteAsync($"Something went wrong.  An error has been logged with id: '{id}'");
                    }
                });
            });
        }
    }

    public class SimplyBooksExceptionHandler
    {

    }
}

