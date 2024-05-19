using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Student.Student.Command.Delete;

public class DeleteStudentCommand: ICommand
{

    public Guid Id{get;set;}
    

}
