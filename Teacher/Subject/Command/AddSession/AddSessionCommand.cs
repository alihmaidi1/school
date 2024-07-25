using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Subject.Command.AddSession;
public class AddSessionCommand: ICommand
{

    public List<Guid> StudentIds{get;set;}

    public Guid SubjectId{get;set;}


}
