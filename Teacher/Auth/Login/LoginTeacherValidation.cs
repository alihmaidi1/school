using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Org.BouncyCastle.Ocsp;

namespace Teacher.Auth.Login;

public class LoginTeacherValidation: AbstractValidator<LoginTeacherCommand>
{

    public LoginTeacherValidation(ApplicationDbContext context){

        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .EmailAddress()
        .Must(email=>context.Teachers.Any(x=>x.Email==email))
        .WithMessage("this teacher is not exists in our data");

        RuleFor(x=>x.Password)
        .NotEmpty()
        .NotNull();

    }

}
