using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Question.Command.Add;

public class AddQuestionCommand: ICommand
{

    public Guid QuezId{get;set;}

    public string? Title{get;set;}

    public Guid? ImageId{get;set;}

    public float Score{get;set;}

    public int Time{get;set;}

    public List<string> Answers{get;set;}

    public string CorrectAnswer{get;set;}

}


