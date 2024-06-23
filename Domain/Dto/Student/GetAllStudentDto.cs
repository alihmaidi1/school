using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Pqc.Crypto.Sike;

namespace Domain.Dto.Student;

public class GetAllStudentDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public string Image{get;set;}

    public string Hash{get;set;}

}
