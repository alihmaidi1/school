using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Parent;
public class GetAllParentBillDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public List<Bill> Bills{get;set;}

    public class Bill{


    public string ClassName{get;set;}

    public DateTimeOffset Date{get;set;}

    public float Money{get;set;}


    }

}
