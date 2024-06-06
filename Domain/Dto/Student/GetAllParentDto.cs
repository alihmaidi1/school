using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetAllParentDto
{

    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string ? Image { get; set; }
    
    public string ? Hash { get; set; }

    public int Children{get;set;}

    public float  RequiredMoney{get;set;}

    public float PayedMoney{get;set;}

    public List<Student> Students{get;set;}


    public class Student{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public string Email{get;set;}

        public string Image{get;set;}

        public string Hash{get;set;}

        
    }



}
