using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom;

namespace Domain.Dto.Student;

public class GetStudentHomeDto
{

    public List<GetAllBannerDto> Banners{get;set;}


    public List<Subject> Subjects{get;set;}
    public class Subject{


        public Guid Id{get;set;}

        public string Name{get;set;}
    }


}
