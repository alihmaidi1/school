using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Abstraction;
using Shared.CQRS;

namespace Admin.ClassRoom.Subject.Query.GetAll;

public class GetAllSubjectCommand: PaginationRequest,ICommand
{



    
    public string? Search{get;set;}
    

}
