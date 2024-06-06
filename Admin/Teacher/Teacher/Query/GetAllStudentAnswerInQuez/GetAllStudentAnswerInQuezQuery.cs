using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllStudentAnswerInQuez;

public class GetAllStudentAnswerInQuezQuery:IQuery
{

    public Guid StudentId{get;set;}


    public Guid QuezId{get;set;}

}
