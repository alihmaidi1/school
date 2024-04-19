using Shared.OperationResult.Base;

namespace Shared.OperationResult.MethodExtension;
using Microsoft.AspNetCore.Mvc;

public static class Result
{
    public static OperationResultBase<T> CreateOperationResultBase<T>(T result,string message,int statusCode,Dictionary<string,string> errors=default) 
    {

        return new OperationResultBase<T>
        {
            Result=result,
            Message=message,
            StatusCode=statusCode,
            Errors = errors

        };

    }
    public static JsonResult ToJsonResult<T>(this OperationResult operationResult, int statusCode, T? result=default(T),string message="") 
    {
        using var operationResultBase=CreateOperationResultBase<T>(result,message,statusCode);
        return new JsonResult(operationResultBase)
        {

            StatusCode=statusCode
        };
        
    }

    public static JsonResult ToJsonValidationResult(this OperationResult operationResult, int statusCode, Dictionary<string,string> errors=default)
    {
        
        
        using var operationResultBase=CreateOperationResultBase<object>(null,"validation error",statusCode,errors);
        return new JsonResult(operationResultBase)
        {

            StatusCode=statusCode,
            
        };
    }

    public static async Task<JsonResult> ToJsonResultAsync<T>(this Task<OperationResult> operationResult, int StatusCode, T? Result = null, string Message = "") where T : class
    {

        return (await operationResult).ToJsonResult(StatusCode,Result,Message);
    }
    
}