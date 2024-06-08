using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Student.Command.PayBill;

public class PayBillValidation: AbstractValidator<PayBillCommand>
{

    public PayBillValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.StudentBills.Any(x=>x.Id==id&&x.PaiedMoney<x.Money))
        .WithMessage("this bill for student is not exists or it is paied");

    }

}
