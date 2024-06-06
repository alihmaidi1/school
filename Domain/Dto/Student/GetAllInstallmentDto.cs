using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetAllInstallmentDto
{

    public Guid Id{get;set;}

    public DateTimeOffset Year{get;set;}
    public string Name{get;set;}




    public float Mark{get;set;}
    

}
