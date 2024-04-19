using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.Quez;

public class GetQuezWithAnswerIds
{


    public Guid Id{get;set;}

    public List<Guid> Answers{get;set;}


}
