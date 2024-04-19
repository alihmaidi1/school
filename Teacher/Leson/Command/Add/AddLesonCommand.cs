using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.CQRS;

namespace Teacher.Leson.Command.Add;

public class AddLesonCommand: ICommand
{



    public Guid SubjectId{get;set;}
    public IFormFile File {get;set;}

    public string Name{get;set;}

}
