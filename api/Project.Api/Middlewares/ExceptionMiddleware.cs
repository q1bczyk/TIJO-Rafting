using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Project.Core.Exceptions;

namespace api;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex, "Validation error: {Message}", ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new ApiExceptionResponse(context.Response.StatusCode, "Wprowadzone dane są nieporpawne", ex.ValidationResult?.ErrorMessage);

            await GenerateResponse(context, response);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new ApiExceptionResponse(context.Response.StatusCode, ex.Message, "Nie znaleziono zasobu");

            await GenerateResponse(context, response);
        }
        catch (ApiControlledException ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            
            if (ex.StatusCode == 400)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            else if (ex.StatusCode == 401)
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            var response = new ApiExceptionResponse(context.Response.StatusCode, ex.Message, ex.Details);

            await GenerateResponse(context, response);
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new ApiExceptionResponse(context.Response.StatusCode, ex.Message, "File not found");

            await GenerateResponse(context, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment()
            ? new ApiExceptionResponse(context.Response.StatusCode, ex.Message, ex.StackTrace)
            : new ApiExceptionResponse(context.Response.StatusCode, ex.Message, "Internal server error");

            await GenerateResponse(context, response);
        }
    }

    private async Task GenerateResponse(HttpContext context, ApiExceptionResponse response)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }
}