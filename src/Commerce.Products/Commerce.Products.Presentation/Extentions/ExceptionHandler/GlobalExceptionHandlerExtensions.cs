using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Commerce.Products.Presentation.Extentions.ExceptionHandler
{
    public static class GlobalExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler<TCategoryName>(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async httpContext =>
                {
                    using var scope = serviceProvider.CreateScope();
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<TCategoryName>>();

                    var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

                    var exception = exceptionHandlerFeature?.Error;

                    if (exception == null)
                    {
                        logger.LogError("An internal server error has occurred. No further details were provided as IExceptionHandlerFeature was not found.");
                        await WriteDefaultResponseAsync(httpContext);
                        return;
                    }

                    await WriteDetailedResponseAsync(httpContext, logger, exception);
                });
            });
        }

        private static async Task WriteDefaultResponseAsync(HttpContext httpContext)
        {
            var problem = new ProblemDetails
            {
                Title = "Erro interno",
                Detail = "Ocorreu um erro interno no servidor.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            await WriteResponseAsync(httpContext, problem, HttpStatusCode.InternalServerError);
        }

        private static async Task WriteDetailedResponseAsync(HttpContext httpContext, ILogger logger, Exception exception)
        {
            if (exception is not InvalidOperationException)
            {
                logger.LogError(exception, "An internal server error has occurred.");
                await WriteDefaultResponseAsync(httpContext);
                return;
            }

            var problem = new ProblemDetails
            {
                Title = "Requisição inválida",
                Detail = exception.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
            };

            await WriteResponseAsync(httpContext, problem, HttpStatusCode.BadRequest);
        }

        private static async Task WriteResponseAsync<T>(HttpContext httpContext, T errorResponse, HttpStatusCode statusCode)
        {
            var serializedResponse = JsonConvert.SerializeObject(errorResponse);

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(serializedResponse);
        }
    }
}