using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Banner.Command.Add;

public class AddBannerCommand: ICommand
{

    public string Name{get;set;}

    public string Url{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public DateTimeOffset EndAt{get;set;}

    public Guid Image{get;set;}

}
