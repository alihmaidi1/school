namespace Dto.Teacher.Vacation;

public class GetAllVacationResponse
{
    
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string Admin { get; set; }
    public string Teacher { get; set; }
    public bool ?Status { get; set; }
    public string Year { get; set; }

}