using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Shared.Abstraction;

namespace Parent.Student.Query.GetStudentMarks;
public class GetParentStudentMarksQuery:IQuery
{

    public Guid StudentId{get;set;}
    

}
