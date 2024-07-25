using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public static class StageSeeder
{

    public static Task SeedData(ApplicationDbContext context){


            if(!context.Stages.Any()){


                var Stages=new List<Stage>();
                Stages.Add(new Stage(){

                    Name="Primary stage",
                    Classes=new List<Class>(){new Class(){ Name="first class",Level=1
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 1",
                            Degree=60

                        },

                        new Subject{

                            Name="English 1",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 1",
                            Degree=60

                        },



                    }
                    
                    },new Class{Name="second class",Level=2,
                    
                    Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 2",
                            Degree=60

                        },

                        new Subject{

                            Name="English 2",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 2",
                            Degree=60

                        },



                    }
                    

                    
                    },new Class{Name="third class",Level=3
                    
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 3",
                            Degree=60

                        },

                        new Subject{

                            Name="English 3",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 3",
                            Degree=60

                        },



                    }
                    
                    }}
                });


                Stages.Add(new Stage(){

                    Name="2th stage",
                    Classes=new List<Class>(){new Class(){ Name="4th class",
                    
                    Level=4
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 4",
                            Degree=60

                        },

                        new Subject{

                            Name="English 4",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 4",
                            Degree=60

                        },



                    }
                    
                    },new Class{Name="5th class",Level=5
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 5",
                            Degree=60

                        },

                        new Subject{

                            Name="English 5",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 5",
                            Degree=60

                        },



                    }
                    

                    },new Class{Name="6th class",Level=6
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 6",
                            Degree=60

                        },

                        new Subject{

                            Name="English 6",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 6",
                            Degree=60

                        },



                    }
                    

                    }}
                });

                Stages.Add(new Stage(){

                    Name="3th stage",
                    Classes=new List<Class>(){new Class(){ Name="7th class",Level=7
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 7",
                            Degree=60

                        },

                        new Subject{

                            Name="English 7",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 7",
                            Degree=60

                        },



                    }
                    
                    },new Class{Name="8th class",Level=8
                    
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 8",
                            Degree=60

                        },

                        new Subject{

                            Name="English 8",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 8",
                            Degree=60

                        },



                    }
                    
                    },new Class{Name="9th class",Level=9
                    ,Subjects=new List<Subject>{
                        
                        new Subject{

                            Name="math 9",
                            Degree=60

                        },

                        new Subject{

                            Name="English 9",
                            Degree=60

                        },

                        new Subject{

                            Name="Arabic 9",
                            Degree=60

                        },



                    }
                    
                    }}

                });

                context.Stages.AddRange(Stages);
                context.SaveChanges();

                
            }

                return Task.CompletedTask;


    }



}
