using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Parent.Home.Query.GetHome;

public class GetHomeValidation: AbstractValidator<GetHomeQuery>
{

    public GetHomeValidation(ApplicationDbContext context,ICurrentUserService currentUserService){





    }

}
