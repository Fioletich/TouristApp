﻿namespace TouristApp.Web.Middleware;

public static class CustomExceptionHandlerMiddlewareExtension {
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}