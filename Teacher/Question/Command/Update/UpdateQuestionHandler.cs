using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                    Name=x,
                    QuestionId=request.Id

                }).ToList();

        Answers.Add(new Answer{

            Name=request.CorrectAnswer,
            IsCorrect=true,
            QuestionId=request.Id
        });
        var question=_context.Questions.First(x=>x.Id==request.Id);        
        question.Name=request.Title;
        question.Score=request.Score;
        question.Time=request.Time;
        _context.Answers.AddRange(Answers);        
        if(request.ImageId is not null){

            var image=_context.Images.First(x=>x.Id==request.ImageId);
            question.Image=image.Url.GetNewPath(FolderName.Question).httpPath;
            _context.SaveChanges();
            image.Url.MoveFile(image.Url.GetNewPath(FolderName.Question).localPath);
        
        }else{

            _context.SaveChanges();
        }

        

        return Success("question updated successfully");

    }
}
