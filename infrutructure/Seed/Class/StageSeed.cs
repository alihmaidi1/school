using Domain.Entities.Subject.Stage;

namespace infrutructure.Seed.Class;

public static class StageSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Stages.Any())
        {
            List<Stage> stages = new List<Stage>()
            {

                new Stage()
                {
                    Name = "Primary Stage",
                    Classes = new List<Domain.Entities.Class.Class.Class>()
                    {
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "First Class"
                        },
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "Second Class"
                        },
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "Third Class"
                        },
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "Fifth Class"
                        },
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "Sexth Class"
                        },
                        
                    }
                    
                },

                new Stage()
                {
                    
                    Name = "Second Stage",
                    Classes = new List<Domain.Entities.Class.Class.Class>()
                    {
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "7th Class"
                            
                        },
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "8th Class"
                            
                        },
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "9th Class"
                            
                        }
                        
                    }
                    
                },
                new Stage()
                {
                    
                    Name = "Advanced Stage",
                    Classes = new List<Domain.Entities.Class.Class.Class>()
                    {
                        
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "10th Class"
                            
                        },
                        
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "11th Class"
                            
                        },
                        
                        new Domain.Entities.Class.Class.Class()
                        {
                            
                            Name = "12th Class"
                            
                        },
                        
                    }
                }

            };
            context.Stages.AddRange(stages);
            context.SaveChanges();

        }
        
    }

    
}