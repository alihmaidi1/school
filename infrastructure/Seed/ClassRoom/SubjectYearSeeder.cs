using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Domain.Entities.Student.StudentBill;
using Domain.Entities.Student.StudentSubject;
using infrastructure.Data.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace infrastructure.Seed.ClassRoom;

    public class SubjectYearSeeder
    {


            public static Task SeedData(ApplicationDbContext context){

                if(!context.SubjectYears.Any()){

                
                    var Classyears=context
                    .ClassYears
                    .Where(x=>x.Status)
                    .Include(x=>x.Class)
                    
                    .ThenInclude(x=>x.Subjects)
                    .ThenInclude(x=>x.TeacherSubjects)
                    .ToList();
                    
                    var SubjectYears=new List<SubjectYear>();     
                    var StudentBill=new List<StudentBill>();     

                    var Student=context.Students.ToList();
                    Classyears.ForEach(x=>{

                        var StudentClass=Student.Where(y=>y.Level<=x.Class.Level).Select(x=>x.Id).OrderBy(x=>Guid.NewGuid()).Take(4).ToList();
                        SubjectYears.AddRange(

                            x.Class.Subjects.Select(y=>new SubjectYear{
                            ClassYearId=x.Id,
                            TeacherSubjectId=y.TeacherSubjects.OrderBy(x=>Guid.NewGuid()).First().Id,
                            StudentSubjects=StudentClass.Select(y=>new StudentSubject{

                                StudentId=y,
                                Mark=new Random().Next(40,100)
                                

                            }).ToList(),
                            
              

                        })
                        .ToList()
                        .Distinct()
                    );

                    StudentClass.ForEach(y=>{

                        StudentBill.AddRange(
                        x.Bills.Select(z=>new StudentBill{
                            BillId=z.Id,
                            Money=z.Money,
                            PaiedMoney=0,
                            StudentId=y

                        }).ToList()

                        );

                    });

                    });
                    context.SubjectYears.AddRange(SubjectYears);
                    context.StudentBills.AddRange(StudentBill);
                    context.SaveChanges();

                }
                                
                return Task.CompletedTask;
            }

    }
