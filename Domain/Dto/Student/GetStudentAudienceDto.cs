using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetStudentAudienceDto
{

    public Guid Id{get;set;}


    public string Name{get;set;}

    public string Image{get;set;}

    public string Hash{get;set;}

    public bool IsExists{get;set;}

}
