using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Manager.Admin.Command.ChangeStatus;

    public class ChangeAdminStatusValidation : AbstractValidator<ChangeAdminStatusCommand>
    {


        public ChangeAdminStatusValidation(ApplicationDbContext context){


            RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull()
            .Must(id=>context.Admins.Any(x=>x.Id==id))
            .WithMessage("admin is not exists in our data");
        }



    }
