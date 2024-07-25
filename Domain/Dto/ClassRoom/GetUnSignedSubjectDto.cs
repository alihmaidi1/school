using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetUnSignedSubjectDto
{


    public Guid Id{get;set;}


    public string Name{get;set;}

    public string Year{get;set;}

    public float MinDegree{get;set;}

    public float Degree{get;set;}

}
