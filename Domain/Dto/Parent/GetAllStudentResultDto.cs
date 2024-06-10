using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Parent;

public class GetAllStudentResultDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}


    public List<Result> Results{get;set;}

    public class Result{


        public DateTimeOffset Date{get;set;}

        public List<SubjectMark> Marks{get;set;}    

        public float Total{get;set;}

    }

    public class SubjectMark{


        public string Name{get;set;}

        public float Mark{get;set;}

    }

}
