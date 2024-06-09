using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Teacher;

public class GetAllVacationDto
{

    public Guid Id{get;set;}

    public string Reson{get;set;}

    public DateTimeOffset Date{get;set;}

    public string Type{get;set;}

    public string Teacher{get;set;}

}
