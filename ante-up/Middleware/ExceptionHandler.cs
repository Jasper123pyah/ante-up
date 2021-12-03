using System.Text.Json;
using System.Threading.Tasks;
using ante_up.Common.ApiModels.Responses;
using Microsoft.AspNetCore.Http;

namespace ante_up.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = ex.ErrorCode;
               
                await response.WriteAsync(JsonSerializer.Serialize(ex.ErrorMessage));
            }
        }
    }
}