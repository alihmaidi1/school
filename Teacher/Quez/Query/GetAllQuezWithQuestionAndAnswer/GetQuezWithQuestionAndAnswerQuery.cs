using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Quez.Query.GetAllQuezWithQuestionAndAnswer;

public class GetQuezWithQuestionAndAnswerQuery:IQuery
{

    public Guid Id{get;set;}

}
