using System.Net;
using System.Text.Json;
using FluentValidation;
using infrutructure;
using Shared.Exceptions;
using Shared.OperationResult.Base;

namespace schoolmanagment.Middleware;

public class ErrorHandling:IMiddleware
{
    ApplicationDbContext DbContext;
        public ErrorHandling(ApplicationDbContext DbContext)
        {

            this.DbContext = DbContext;

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
                DbContext.Database.BeginTransaction();             

                
				await next(context);

                DbContext.Database.CommitTransaction();

            }
            catch (Exception error)
            {
            
                DbContext.Database.RollbackTransaction();
                var response=context.Response;
                response.ContentType= "application/json";
                var Result = new OperationResultBase<string>() { };


                switch (error)
                {


                    case ValidationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        Result.Errors = exception.Errors.GroupBy(e => e.PropertyName).ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).ToList());

                        break;

                    case UnAuthenticationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    case UnAuthorizationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.Forbidden;
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;

                    case Exception exception:
                        Result.Message = exception.Message;
                        Result.StatusCode= (int)HttpStatusCode.InternalServerError;
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                    default :
                        Result.Message = error.Message;
                        Result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;


                }

                var errors= JsonSerializer.Serialize(Result);
                await response.WriteAsync(errors);

            }
        }
    
}