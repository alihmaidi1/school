using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Student.Student.Command.Add;

public class AddStudentCommand: ICommand
{

    public string Name{get;set;}

    public string Email{get;set;}

    public string Password{get;set;}


    public bool Gender{get;set;}


    public Guid ParentId{get;set;}

    public Guid Image{get;set;}


    public int Level{get;set;}




}
