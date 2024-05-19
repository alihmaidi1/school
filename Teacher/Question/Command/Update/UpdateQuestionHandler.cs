using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.OperationResult;

namespace Teacher.Question.Command.Update;

public class UpdateQuestionHandler : OperationResult, ICommandHandler<UpdateQuestionCommand>
{

    private ApplicationDbContext _context;
    public UpdateQuestionHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {


        var Answers=request.Answers.Select(x=>new Answer(){

                Name=x

            }).ToList();

        Answers.Add(new Answer{

            Name=request.CorrectAnswer,
            IsCorrect=true
        });

        
        var question=new Domain.Entities.Quez.Question(){

            Id=request.Id,
            Name=request.Title,
            Score=request.Score,
            Time=request.Time,
            Answers=Answers


        };

        if(request.ImageId is not null){

            var image=_context.Images.First(x=>x.Id==request.ImageId);
            question.Image=image.Url.GetNewPath(FolderName.Question).httpPath;
            _context.Questions.Update(question);
            _context.SaveChanges();
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Question).localPath);
        
        }else{

            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        

        return Success("question updated successfully");

    }
}
