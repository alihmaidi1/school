namespace Shared.Exceptions;

public class CannotSendEmailException:Exception
{
    public CannotSendEmailException(string message):base(message) {
        
    }   
}