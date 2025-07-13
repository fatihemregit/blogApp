﻿using BlogApp.Models.Exceptions;
using System.Net;

namespace BlogApp.Utils.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // inner exception'ı logla
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Console.WriteLine(error); // veya logger.LogError(error)

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine("handle exception çalıştı");
            context.Response.ContentType = "application/json";
            if (exception is CustomException)
            {
                context.Response.StatusCode = _env.IsDevelopment() ? ((CustomException)exception).DevelopmentEnvironmentStatusCode : ((CustomException)exception).ProductionEnvironmentStatusCode;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            //Öneri : customException sa loglamayı zaten yapmış oluruz. o yüzden sadece dahili hataları log error yapalım

            var response = new
            {
                status = context.Response.StatusCode,
                message = _env.IsDevelopment() ? exception.Message : "An unexpected error occurred.",
                stackTrace = _env.IsDevelopment() ? exception.StackTrace : ""
            };
            Console.WriteLine("hata var !!!!");
            Console.WriteLine("==================================");
            Console.WriteLine($"hata açıklaması(message) : {exception.Message}\nHata demeti : {exception.StackTrace}");
            Console.WriteLine("==================================");

            if (_env.IsDevelopment())
            {
                Console.WriteLine(exception.StackTrace);
            }

            return context.Response.WriteAsJsonAsync(response);
        }

    }
}
