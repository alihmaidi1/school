using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.ClassRoom;

public class GetAllStudentBillDto
{

    public Guid BillId{get;set;}

    public Guid StudentId{get;set;}

    public float Money{get;set;}

    public string StudentName{get;set;}

}
