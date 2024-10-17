using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

using Ticketing.Shared.Core.Exceptions;

namespace Ticketing.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private static readonly string ErrorMessage = "An unhandled exception was thrown by the application.";
        public void OnException(ExceptionContext context)
        {
            if (context?.Exception == null) 
            {
                return;
            }

            switch (context.Exception) 
            {
                case ResourceNotFoundException resourceNotFoundException:
                    SetupContextForException(context, HttpStatusCode.NotFound, resourceNotFoundException.Message);
                    break;
                case ResourceDuplicateException resourceDuplicateException:
                    SetupContextForException(context, HttpStatusCode.Conflict, resourceDuplicateException.Message);
                    break;
                default:
                    SetupContextForException(context, HttpStatusCode.InternalServerError, ErrorMessage);
                    break;
            }

        }

        private void SetupContextForException(ExceptionContext context, HttpStatusCode statusCode, string message)
        {
            context.Result = new JsonResult(message)
            {
                StatusCode = (int)statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
