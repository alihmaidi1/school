
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Account;
using Domain.Event;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.Parent;

public class Parent:Domain.Entities.Account.Account
{

    public Parent()
    {

        Id = Guid.NewGuid();
        Students = new HashSet<Student.Student>();
    }


    public void SendEmail(string Subject,string Message){

        RaiseDomainEvent(new SendEmailEvent(){

            Email=Email,
            Subject=Subject,
            Message=Message


            
        });

    }
    
    public string? Code{get;set;}
    
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }

    public string? Hash { get; set; }
    public ICollection<Student.Student> Students { get; set; }
}