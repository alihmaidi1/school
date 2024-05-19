using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Teacher.Teacher.Command.ChangeStatus;

public class ChangeTeacherStatusCommand: ICommand
{

    public Guid Id{get;set;}

    public bool Status{get;set;}

    public string? Reason{get;set;}

}
