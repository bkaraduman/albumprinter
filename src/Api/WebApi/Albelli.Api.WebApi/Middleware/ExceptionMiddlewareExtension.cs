using Albelli.Common.Infrastructure.Exceptions;
using Albelli.Common.Models;
using System.Net;

namespace Albelli.Api.WebApi.Middleware
{
    public class ExceptionMiddlewareExtension
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewareExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (PermissionException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.ErrorCode);
            }
            catch (ServiceException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.ErrorCode);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.ErrorCode);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.ErrorCode);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            return context.Response.WriteAsync(new ApiResponseDto()
            {
                Message = message,
                Result = null,
                IsSuccess = false,
                StatusCode = statusCode
            }.ToString());
        }
    }
}
