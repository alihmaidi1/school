using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Teacher.Quez.Query.GetQuestion;

public class GetQuezQuestionQuery:PaginationRequest,IQuery
{

    public Guid QuezId{get;set;}    


}
