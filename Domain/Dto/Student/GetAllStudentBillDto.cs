using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetAllStudentBillDto
{

    public float Sum{get;set;}


    public List<StudentBill> StudentBills{get;set;}
    public class StudentBill{


        public Guid Id{get;set;}

        public float Money{get;set;}

        


    }

}
