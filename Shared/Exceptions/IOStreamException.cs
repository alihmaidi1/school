namespace Shared.Exceptions;

public class IOStreamException:Exception
{
 
    public IOStreamException(string message): base("IOStream Error :( : "+message)
    {
        
    }

    
}