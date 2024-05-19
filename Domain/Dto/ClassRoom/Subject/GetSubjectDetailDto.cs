using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom.Subject;

public class GetSubjectDetailDto
{

    public Guid Id{get;set;}


    public string Name{get;set;}

    public float Degree{get;set;}

    public float MinDegree{get;set;}

    public int StudentNumber{get;set;}

}
