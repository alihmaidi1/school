using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Student.Command.AddMark;

public class AddMarkCommand:ICommand
{

    public Guid SubjectId{get;set;}


    public Guid StudentId{get;set;}

    public float Mark{get;set;}

}
