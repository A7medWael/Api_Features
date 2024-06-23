using ApiDemoo.ResponseMedule;
using System.Net;
using System.Text.Json;

namespace ApiDemoo.MiddleWares
{
    public class ExpetionMiddleWares
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ExpetionMiddleWares> _logger;
        public ExpetionMiddleWares(RequestDelegate next, ILogger<ExpetionMiddleWares> logger, IHostEnvironment hostEnvironment)
        {
            _next = next;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                var respone = _hostEnvironment.IsDevelopment() ?
                    new ApiExp((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                    new ApiExp((int)HttpStatusCode.InternalServerError);
                var options=new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json=JsonSerializer.Serialize(respone, options);
                await httpContext.Response.WriteAsync(json);

            }
        }
    }

}