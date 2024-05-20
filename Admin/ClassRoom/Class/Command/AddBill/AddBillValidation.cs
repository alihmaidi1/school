using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Class.Command.AddBill;

public class AddBillValidation: AbstractValidator<AddBillCommand>
{

    public AddBillValidation(ApplicationDbContext context){

        

    }

}
