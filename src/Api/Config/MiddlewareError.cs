using Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Api.Config
{
    public class MiddlewareError
    {
        private readonly RequestDelegate _next;

        public MiddlewareError(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;

            if (exception is AlredyExistsException)
                code = HttpStatusCode.Conflict;
            else
            {
                code = HttpStatusCode.InternalServerError;
                
            }

            var response = new { exception.Message };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
