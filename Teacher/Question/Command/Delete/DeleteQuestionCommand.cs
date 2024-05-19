using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Question.Command.Delete;

public class DeleteQuestionCommand: ICommand
{

    public Guid Id{get;set;}


}
