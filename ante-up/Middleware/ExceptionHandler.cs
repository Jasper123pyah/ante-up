using System.Text.Json;
using System.Threading.Tasks;
using ante_up.Common.ApiModels;
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
                if (ex.ErrorCode == 401 || 
                    ex.ErrorCode == 402 || 
                    ex.ErrorCode == 404 ||
                    ex.ErrorCode == 409 ||
                    ex.ErrorCode == 500)
                {
                    await response.WriteAsync(JsonSerializer.Serialize(ex.ErrorMessage));
                    return;
                }

                await response.WriteAsync("");
            }
        }
    }
}