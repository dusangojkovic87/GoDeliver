using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Authentication.API.Exceptions;

namespace Authentication.API.ExceptionMiddlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);

            }
            catch (CustomValidationException ex)
            {

                await HandleValidationErrorsAsync(context, ex);
            }


        }

        private static async Task HandleValidationErrorsAsync(HttpContext context, CustomValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";




            var errors = new Dictionary<string, string[]>
            {
                { "ValidationErrors", ex.Errors.ToArray() }
            };

            await JsonSerializer.SerializeAsync(context.Response.Body, errors);

            await context.Response.Body.FlushAsync();


        }


    }


}