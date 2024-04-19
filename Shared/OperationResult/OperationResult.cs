using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult.Enum;
using Shared.OperationResult.MethodExtension;

namespace Shared.OperationResult;

public class OperationResult
{
    public OperationResult() {
        
    }    



    public JsonResult Deleted()
    {
                
        const int statusCode = (int)System.Net.HttpStatusCode.OK;
        const string message = "Deleted Successfully";
        return this.ToJsonResult<object>(statusCode:statusCode,message:message);
    }

    public  JsonResult NotFound<T>(string message="") where T : class
    {
        const int statusCode = (int)OperationResultType.OperationResultTypes.NotExist;

        return this.ToJsonResult<T>(statusCode: statusCode, message: message);
    }

    public JsonResult Success<T>(T data,string resultMessage="") 
    {
        const int statusCode = (int)System.Net.HttpStatusCode.OK;
        //string Message = _StringLocalizer[SharedResourceKeys.Operation_Success];
        return this.ToJsonResult<T>(statusCode, data, resultMessage);

    }

    public JsonResult Success(string resultMessage = "")
    {
        const int statusCode = (int)System.Net.HttpStatusCode.OK;
        return this.ToJsonResult<object>(statusCode,message:resultMessage);

    }

    
    public JsonResult Fail(string resultMessage = "")
    {
        const int statusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity;
        return this.ToJsonResult<object>(statusCode,message:resultMessage);

    }
    public JsonResult Created<T>(T data, string message = "")
    {
        const int statusCode = (int)System.Net.HttpStatusCode.Created;
        return this.ToJsonResult<T>(statusCode,data,message);
    }
    public JsonResult ValidationError(string propertyName,string propertyMessage)
    {
        // const T data=
        const int statusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity;
        Dictionary<string, string> errors = new Dictionary<string, string>();
        errors.Add(propertyName,propertyMessage);
        return this.ToJsonValidationResult(statusCode,errors);
    }
    public  JsonResult Exists<T>(string message="") where T : class
    {
        const int statusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity;
        return this.ToJsonResult<T>(statusCode,message:message);
    }
   
}