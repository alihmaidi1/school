using FluentValidation;
using infrastructure;
using Repository.Teacher.Teacher;

namespace Admin.Teacher.Teacher.Command.Add;

public class AddTeacherValidation:AbstractValidator<AddTeacherCommand>
{
    
    
    public AddTeacherValidation(ApplicationDbContext context,ITeacherRepository teacherRepository)
    {

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .Must(email=>!teacherRepository.IsExistsByProperty("Email",email));


        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);


        RuleFor(x=>x.Image)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .WithMessage("image is not exists in our data");

        

    }

    
}