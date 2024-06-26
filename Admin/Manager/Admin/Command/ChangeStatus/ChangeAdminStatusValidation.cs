using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Admin.Manager.Admin.Command.ChangeStatus;

    public class ChangeAdminStatusValidation : AbstractValidator<ChangeAdminStatusCommand>
    {


        public ChangeAdminStatusValidation(ApplicationDbContext context){


            RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull()
            .Must(id=>context.Admins.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Id==id))
            .WithMessage("admin is not exists in our data");
        }



    }
