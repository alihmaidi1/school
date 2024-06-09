using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetStudentWithStatusDto
{

    public Guid Id{get;set;}


    public int Level {get;set;}

    public bool Status{get;set;}

}
