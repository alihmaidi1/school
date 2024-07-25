using FluentValidation;
using infrastructure;

namespace Admin.Notification.Command.Send;

public class SendNotificationValidation: AbstractValidator<SendNotificationCommand>
{

    public SendNotificationValidation(ApplicationDbContext context){

        RuleFor(x=>x.Title)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Body)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Ids)
        .Must(ids=>ids!=null &&context.Students.Where(x=>ids.Contains(x.Id)).Count()==ids.Count())
        .When(x=>x.NotificationType==Domain.Enum.NotificationType.Student)
        .WithMessage("some id is not correct");


        RuleFor(x=>x.Ids)
        .Must(ids=>ids!=null &&context.Teachers.Where(x=>ids.Contains(x.Id)).Count()==ids.Count())
        .When(x=>x.NotificationType==Domain.Enum.NotificationType.Teacher)
        .WithMessage("some id is not correct");


        RuleFor(x=>x.Ids)
        .Must(ids=>ids!=null &&context.Parents.Where(x=>ids.Contains(x.Id)).Count()==ids.Count())
        .When(x=>x.NotificationType==Domain.Enum.NotificationType.Parent)
        .WithMessage("some id is not correct");


        RuleFor(x=>x.Ids)
        .Must(ids=>ids!=null &&context.Classes.Where(x=>ids.Contains(x.Id)).Count()==ids.Count())
        .When(x=>x.NotificationType==Domain.Enum.NotificationType.Class)
        .WithMessage("some id is not correct");

        

        

    }

}
