using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Quez.Query.GetStudentAnswer;

public class GetStudentAnswerQuery: IQuery
{

    public Guid StudentId{get;set;}

    public Guid QuezId{get;set;}

}
