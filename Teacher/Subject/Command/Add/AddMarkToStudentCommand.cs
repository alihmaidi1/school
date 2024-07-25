using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Subject.Command.Add;

public class AddMarkToStudentCommand: ICommand
{

    public Guid StudentId{get;set;}


    public Guid SubjectId{get;set;}
    public float Mark{get;set;}


}
