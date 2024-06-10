using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllBannerDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}


    public DateTimeOffset StartAt{get;set;}

    public DateTimeOffset EndAt{get;set;}

    public string Image{get;set;}

    public string Url{get;set;}



}
