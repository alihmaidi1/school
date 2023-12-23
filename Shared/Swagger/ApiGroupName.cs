namespace Shared.Swagger;

public enum ApiGroupName
{
    
    [GroupInfoAttribute(Title = "All Title", Description = "All Description", Version ="v1")]
    All = 0,

    [GroupInfoAttribute(Title = "Dashboard Title", Description = "Dashboard Title", Version = "v1")]
    Admin = 1,

    [GroupInfoAttribute(Title = "Teacher Title", Description = "Teacher Description", Version = "v1")]
    Teacher = 2,

    [GroupInfoAttribute(Title = "Student Title", Description = "Student Decription", Version = "v1")]
    Student = 3,


    
    [GroupInfoAttribute(Title = "Parent Title", Description = "Parent Decription", Version = "v1")]
    Parent = 4,

}