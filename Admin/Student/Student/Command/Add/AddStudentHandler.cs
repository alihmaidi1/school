using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.Student;
using Domain.Entities.Student.StudentBill;
using Domain.Entities.Student.StudentSubject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.Helper;
using Shared.OperationResult;

namespace Admin.Student.Student.Command.Add;

public class AddStudentHandler : OperationResult ,ICommandHandler<AddStudentCommand>
{   

    private ApplicationDbContext _context;

    public AddStudentHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {

        var image=_context.Images.First(x=>x.Id==request.Image);
        var Bills=_context
        .Bills
        .Where(x=>x.ClassId==request.ClassId)
        .Where(x=>x.Year.Date.Year==DateTime.Now.Year)
        .Select(x=>new StudentBill{


                Date=x.Date,
                Money=x.Money


        })
        .ToList();


        var StudentSubjects=_context
        .SubjectYears
        .Where(x=>x.Subject.ClassId==request.ClassId)
        .Where(x=>x.Year.Date.Year==DateTime.Now.Year)
        .Select(x=>new StudentSubject{


            SubjectYearId=x.Id

        })
        .ToList();
        if(!StudentSubjects.Any()||!Bills.Any()){

            throw new Exception("this year info for this class is not complete");
        }
        var Student=new Domain.Entities.Student.Student.Student(){

            Name=request.Name,
            Email=request.Email,
            Password=PasswordHelper.HashPassword(request.Password),
            Image = image.Url.GetNewPath(FolderName.Parent).httpPath,
            Hash=image.Hash,
            ParentId=request.ParentId,
            Gender=request.Gender,
            StudentBills=Bills,
            StudentSubjects=StudentSubjects          

        };
        Student.SendEmail("you are a new student in school",$"this is your password{request.Password}");
        _context.Students.Add(Student);
        _context.Images.Remove(image);

        _context.SaveChanges();

        image.Url.MoveFile(image.Url.GetNewPath(FolderName.Student).localPath);


        return Success("student was added successfully");

    }
}
