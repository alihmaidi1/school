using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Student.Audience;
using Domain.Entities.Student.StudentSubject;

namespace Domain.Entities.ClassRoom;

    public class SubjectYear:BaseEntity,ISoftDelete
    {

        public SubjectYear(){

            Id=Guid.NewGuid();
            StudentSubjects=new HashSet<StudentSubject>();
            Audiences=new HashSet<Audience>();        
            Lesons=new HashSet<Leson>();
            Programs=new HashSet<Program>();
        }



        
        public Teacher.Teacher.Teacher Teacher{get;set;}

        public Guid TeacherId{get;set;}


        public ClassYear ClassYear{get;set;}

        public Guid ClassYearId{get;set;}
    
        public ICollection<Audience> Audiences{get;set;}




        public ICollection<StudentSubject> StudentSubjects{get;set;}

        public ICollection<Leson> Lesons{get;set;}

        public ICollection<Program> Programs{get;set;}

}
