namespace Dto.Teacher.Warning;

public class GetAllWarningResponse
{
    
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string ManagerName { get; set; }
    public int Date { get; set; }

}