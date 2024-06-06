using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Notification;

public class GetAllNotificationDto
{

    public Guid Id{get;set;}


    public string Title{get;set;}

    public string Body{get;set;}

    public DateTimeOffset Date{get;set;}

    public Dictionary<string,string> Data{get;set;}

}
