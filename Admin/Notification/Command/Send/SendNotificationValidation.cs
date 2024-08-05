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
        .Must(ids=>context.Accounts.Where(x=>ids.Contains(x.Id)).Count()==ids.Count())
        .WithMessage("some id is not correct");


        

        

    }

}
