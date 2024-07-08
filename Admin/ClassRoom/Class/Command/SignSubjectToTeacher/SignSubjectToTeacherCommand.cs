using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.ClassRoom.Class.Command.SignSubjectToTeacher;

public class SignSubjectToTeacherCommand:ICommand
{


    public Guid SubjectId{get;set;}


    public Guid TeacherId{get;set;}

    

}
