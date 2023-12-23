namespace Shared.Swagger;

public class ApiGroupAttribute:System.Attribute
{
    
    
    public ApiGroupAttribute(params ApiGroupName[] name)
    {
        GroupName = name;
    }
    public ApiGroupName[] GroupName { get; set; }

    
}