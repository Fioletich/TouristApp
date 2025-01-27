using System.Net;
using System.Text.Json;
using FluentValidation;
using Serilog;
using TouristApp.Application.Exceptions;

namespace TouristApp.Web.Middleware;

public class CustomExceptionHandlerMiddleware {
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
        _next = next;

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

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (ex)
        {
            case ValidationException exception:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(exception.Errors);
                break;
            case NotFoundException exception:
                code = HttpStatusCode.NotFound;
                break;
            case ArgumentException exception:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if(result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { error = ex.Message });
        }
        Log.Error("Exception: {Result}", result);

        return context.Response.WriteAsync(result);
    }
}