using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Teacher;

public class GetAllTeacherDto
{

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    
    public string? Image { get; set; }

    public string? Hash { get; set; }


    public List<Guid> SubjectIds{get;set;}

    public int StudentNumber{get;set;}
    

    public int SubjectNumber{get;set;}


}
