using Domain.Base.Entity;
using Domain.Base.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace infrastructure.BackgroundJob;

public class ProcessOutboxMessageJob
{

    private static string Locker = string.Empty;


    private readonly IPublisher _publisher;
    private readonly ApplicationDbContext _context;


    public ProcessOutboxMessageJob(IPublisher publisher,ApplicationDbContext context)
    {

        _publisher=publisher;
        _context=context;



    }


    public async Task Process(){


        lock(Locker){

            Console.WriteLine("_______________________________ process started _______________________________");
            var transaction=_context.Database.BeginTransaction();
            var outboxMessages=_context.OutBoxMessages.ToList();
            List<Guid> successedOutbox=new List<Guid>();
            List<OutBoxMessage> failedOutbox=new List<OutBoxMessage>();
            foreach (var outBoxMessage in outboxMessages)
            {
            
                try{ 
                IBaseEvent? domainEvent=JsonConvert.DeserializeObject<IBaseEvent>(outBoxMessage.Content,new JsonSerializerSettings{

                    TypeNameHandling=TypeNameHandling.All
                });

                if(domainEvent is null) continue;
                _publisher.Publish(domainEvent).GetAwaiter().GetResult();
                successedOutbox.Add(outBoxMessage.Id);
                }catch(Exception Exception){

                    outBoxMessage.Error=JsonConvert.SerializeObject(Exception);
                    failedOutbox.Add(outBoxMessage);
                }        

            }
            _context.OutBoxMessages.Where(x=>successedOutbox.Contains(x.Id)).ExecuteDelete();
            if(failedOutbox.Any()){

            _context.OutBoxMessages.UpdateRange(failedOutbox);        

            }
            _context.SaveChanges();
            transaction.Commit();

            Console.WriteLine("_______________________________ process ended___________________________________");


        }

        
    }

}
