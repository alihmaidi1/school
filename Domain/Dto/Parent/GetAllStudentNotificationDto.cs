using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Parent;

public class GetAllStudentNotificationDto
{


    public Guid Id{get;set;}

    public string Title{get;set;}

    public string Body{get;set;}

    public string StudentName{get;set;}


}
