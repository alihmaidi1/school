using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.OperationResult;

namespace Teacher.Question.Command.Add;

public class AddQuestionHandler :OperationResult, ICommandHandler<AddQuestionCommand>
{

    private ApplicationDbContext _context;

    public AddQuestionHandler(ApplicationDbContext context)
    {

        _context=context;

    }
    public async Task<JsonResult> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
    {


        var Answers=request.Answers.Select(x=>new Answer(){

                Name=x

            }).ToList();

        Answers.Add(new Answer{

            Name=request.CorrectAnswer,
            IsCorrect=true
        });
        var question=new Domain.Entities.Quez.Question(){

            Name=request.Title,
            Time=request.Time,
            Score=request.Score,
            QuezId=request.QuezId,
            Answers=Answers,
            
            
        };
        if(request.ImageId is not null){

            var image=_context.Images.First(x=>x.Id==request.ImageId);
            question.Image=image.Url.GetNewPath(FolderName.Question).httpPath;
            _context.Questions.Add(question);
            _context.SaveChanges();
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Question).localPath);
        
        }else{

            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        

        return Success("question was added to this quez successfully");
    }
}
