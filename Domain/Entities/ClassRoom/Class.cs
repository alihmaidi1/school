using Domain.Base.Entity;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Class: BaseEntity,ISoftDelete
    {

        public Class(){

            Id=Guid.NewGuid();
            Subjects=new HashSet<Subject>();
            Bills=new HashSet<Bill>();
            ClassYears=new HashSet<ClassYear>();
        }

        public string Name{get;set;}



        public int Level{get;set;}

        public Guid StageId{get;set;}

        public Stage Stage{get;set;}




        public ICollection<Subject> Subjects{get;set;} 

        public ICollection<ClassYear> ClassYears{get;set;}

        public ICollection<Bill> Bills{get;set;}

    }
