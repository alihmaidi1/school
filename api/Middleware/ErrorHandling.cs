using System.Net;
using System.Text.Json;
using FluentValidation;
using infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.Interface;
using Shared.Exceptions;
using Shared.OperationResult.Base;

namespace schoolmanagment.Middleware;

public class ErrorHandling:IMiddleware, IBaseSuper
{
    readonly ApplicationDbContext _dbContext;
        public ErrorHandling(ApplicationDbContext dbContext)
        {

            this._dbContext = dbContext;

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
                await _dbContext.Database.BeginTransactionAsync();             

                
				await next(context);

                await _dbContext.Database.CommitTransactionAsync();

            }
            catch (Exception error)
            {
            
                await _dbContext.Database.RollbackTransactionAsync();
                var response=context.Response;
                response.ContentType= "application/json";
                var result = new OperationResultBase<string>() { };


                switch (error)
                {


                    case ValidationException exception:
                        result.Message = exception.Message;
                        result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        result.Errors = exception.Errors.GroupBy(e => e.PropertyName).ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).FirstOrDefault());
                        break;

                    case UnAuthenticationException exception:
                        result.Message = exception.Message;
                        result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case DbUpdateException exception:
                    
                        var innerexception = exception.InnerException;
                        if (innerexception is SqlException&& ((SqlException)(innerexception)).ErrorCode==-2146232060)
                        {
                            result.Message = innerexception.Message;
                            result.StatusCode= (int)HttpStatusCode.InternalServerError;
                            response.StatusCode= (int)HttpStatusCode.InternalServerError;
                            break;
                    
                        }
                        else
                        {
                            
                            result.Message = exception.Message;
                            result.StatusCode= (int)HttpStatusCode.InternalServerError;
                            response.StatusCode= (int)HttpStatusCode.InternalServerError;
                            break;
                            
                            
                        }
                        
                        ;
                    


                    case UnAuthorizationException exception:
                        result.Message = exception.Message;
                        result.StatusCode = (int)HttpStatusCode.Forbidden;
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;

                    // case Exception exception:
                    //     result.Message = exception.Message;
                    //     result.StatusCode= (int)HttpStatusCode.InternalServerError;
                    //     response.StatusCode= (int)HttpStatusCode.InternalServerError;
                    //     break;
                    default :
                        result.Message = error.Message;
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;


                }

                var errors= JsonSerializer.Serialize(result);
                await response.WriteAsync(errors);

            }
        }
    
}