using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Question.Command.Update;

public class UpdateQuestionCommand: ICommand
{


    public Guid Id{get;set;}


    public string? Title{get;set;}

    public Guid? ImageId{get;set;}

    public float Score{get;set;}

    public int Time{get;set;}

    public List<string> Answers{get;set;}

    public string CorrectAnswer{get;set;}


}
