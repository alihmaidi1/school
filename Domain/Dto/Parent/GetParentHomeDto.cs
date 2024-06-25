using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;
using Dto.Admin.Auth.Dto;
using Domain.Dto.Notification;
using Domain.Dto.Student;

namespace Domain.Dto.Parent;

public class GetParentHomeDto
{



    public List<GetAllBannerDto> Banners{get;set;}


    public List<GetAllStudentDto> Students{get;set;}

    public List<GetAllStudentNotificationDto> Notifications{get;set;}


    public int NotificationCount{get;set;}


}
