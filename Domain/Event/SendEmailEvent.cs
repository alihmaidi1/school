using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.interfaces;

namespace Domain.Event;

public class SendEmailEvent: IBaseEvent
{

    public string Message{get;set;}

    public string Subject{get;set;}

    public string Email{get;set;}


}
