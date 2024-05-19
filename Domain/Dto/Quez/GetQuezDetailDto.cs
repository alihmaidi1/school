namespace Domain.Dto.Quez;

public class GetQuezDetailDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public string StartAt{get;set;}

    public List<Question> Questions{get;set;}
    
    public List<Student> Students{get;set;}
    
    
    public class Question{

        public Guid Id{get;set;}

        public string Name{get;set;}
        public List<Answer> Answers{get;set;}
        

        

    }

    public class Answer{


        public Guid Id{get;set;}
        public string Name{get;set;}

        public bool isCorrect{get;set;}
    }


    public class Student{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public string Image{get;set;} 
    
        public float Precent{get;set;}
    }

}
