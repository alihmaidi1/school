using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllClassBillDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public int Recived{get;set;}


    public int  Remaining{get;set;}

    public float Total{get;set;}

    public bool Status{get;set;}

}
