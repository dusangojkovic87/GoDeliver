using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Models;

namespace Authentication.API.ExceptionMiddlewares
{
    public class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Message = "Error happend,try again!",
                Details = ex.Message

            };

            // Serialize the response and send it back to the client
            await context.Response.WriteAsJsonAsync(errorResponse);
        }

    }
}