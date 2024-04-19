using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;
using Shared.OperationResult.Base;
using ValidationException = FluentValidation.ValidationException;
namespace Shared.ExtensionMethod;

public static class ActionMethods
{
    public static Action<Exception, HttpContext> HandlerExceptionCase = async (error, context) =>
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var result = new OperationResultBase<string>();


        switch (error)
        {
            case ValidationException exception:
                result.Message = exception.Message;
                result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                result.Errors = exception.Errors.GroupBy(e => e.PropertyName)
                    .ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).FirstOrDefault());

                break;

            case UnAuthenticationException exception:
                result.Message = exception.Message;
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;


            case UnAuthorizationException exception:
                result.Message = exception.Message;
                result.StatusCode = (int)HttpStatusCode.Forbidden;
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                break;


            case DbUpdateException exception:

                var innerexception = exception.InnerException;
                if (innerexception is SqlException && ((SqlException)innerexception).ErrorCode == -2146232060)
                {
                    result.Message = "you can't delete this record becuase it is have relation data";
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                }

                result.Message = exception.Message;
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;

                ;
            // case Exception exception:
            //     result.Message = exception.Message;
            //     result.StatusCode = (int)HttpStatusCode.InternalServerError;
            //     response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //     break;

            default:
                result.Message = error.Message;
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }


        var errors = JsonSerializer.Serialize(result);
        await response.WriteAsync(errors);
    };
}