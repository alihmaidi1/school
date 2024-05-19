using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.EntityOperation;

namespace Domain.Dto.ClassRoom.Subject;

public class GetAllSubjectByYearDto
{

    public int TotalTeacher{get;set;}


    public PageList<Subject> Subjects{get;set;}

    public class Subject{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public string Year{get;set;}

        public float Degree{get;set;}

        public float MinDegree{get;set;}


    }

}
