using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Banner.Command.Delete;
public class DeleteBannerCommand: ICommand
{

    public Guid Id{get;set;}

    

}
