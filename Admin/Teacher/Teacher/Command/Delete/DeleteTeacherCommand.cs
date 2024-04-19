using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Teacher.Teacher.Command.Delete;

public class DeleteTeacherCommand: ICommand
{

    public Guid Id{get;set;}


}
