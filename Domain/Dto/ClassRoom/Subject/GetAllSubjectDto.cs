using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom.Subject;

public class GetAllSubjectDto
{

    public Guid Id{get;set;}

    public string SubjectName{get;set;}

    public string Year{get;set;}

    public float Degree{get;set;}

    public float MinDegree{get;set;}

    public bool Status{get;set;}


}
