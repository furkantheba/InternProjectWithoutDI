using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1.Handlers;

public class GlobalExceptionHandler: IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Beklenmeyen bir hata oluştu: {Message}", exception.Message);


   
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";
        
        var response = new
        {
            statusCode = 500,
            title = "Sunucu Hatası",
            message = "Beklenmeyen bir arıza meydana geldi.",
            detail = exception.Message
        };
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);


        return true; 
    }
}