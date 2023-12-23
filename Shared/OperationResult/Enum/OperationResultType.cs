namespace Shared.OperationResult.Enum;

public class OperationResultType
{
    public enum OperationResultTypes
    {
        Success,
        Exist,
        NotExist=429,
        Failed,
        Forbidden,
        Exception,
        Unauthorized
    }
    
}