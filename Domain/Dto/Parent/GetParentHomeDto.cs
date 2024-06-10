using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;
using Domain.Dto.Notification;

namespace Domain.Dto.Parent;

public class GetParentHomeDto
{



    public List<GetAllBannerDto> Banners{get;set;}


    public List<GetAllNotificationDto> Notifications{get;set;}

}
