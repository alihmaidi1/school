using System.Runtime.InteropServices;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Account;
using Domain.Entities.Teacher.Vacation;
using Domain.Entities.Teacher.Warning;
using Domain.Event;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shared.Entity.Entity;

namespace Domain.Entities.Manager.Admin;

public class Admin: Account.Account,ISoftDelete
{

    
    public Admin()
    {

        Id = Guid.NewGuid();
        Vacations = new HashSet<Vacation>();
        Warnings = new HashSet<Warning>();


    }

 
    public void SendEmail(string Subject,string Message){

        RaiseDomainEvent(new SendEmailEvent(){

            Email=Email,
            Subject=Subject,
            Message=Message


            
        });

    }

    public string Name { get; set; }
    
    public bool Status { get; set; }=true;
    
    public Guid RoleId { get; set; }
    public  Role.Role Role { set; get; }
    
    public string Image { get; set; }
    
    public string Hash { get; set; }


    public ICollection<Vacation> Vacations { get; set; } 
    public ICollection<Warning> Warnings { get; set; }
    
    
}