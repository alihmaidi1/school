using System.Reflection;
using Admin;
using Common;
using FluentValidation;
using infrutructure;
using infrutructure.Seed;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;
using Repository;
using schoolmanagment.Base;
using schoolmanagment.Middleware;
using Shared.Jwt;
using Shared.Redis;
using Shared.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddOpenApi();


// api area
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ErrorHandling>();

// end api area




// common area

builder.Services.AddCommondependency();

// end common area



// infrustucture area
builder.Services.AddInfrustucture(builder.Configuration);

// end infrustucture area


// repository area
builder.Services.AddRepository();

// end repository area



// admin area

builder.Services.AddAdmindependency();

// end admin area


// shared area
builder.Services.AddJwtConfigration(builder.Configuration);

// end shared area



builder.Services.AddRateLimiter(Limitrateoption =>
{

    Limitrateoption.AddFixedWindowLimiter("fixedwindow", option =>
    {

        option.PermitLimit = 2;
        option.Window=TimeSpan.FromSeconds(1);
        option.QueueLimit = 0;
    });


});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", policyBuilder =>
    {
        policyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<ICacheRepository,CacheRepository>();


builder.Services.AddSwaggerGen();


var app = builder.Build();

app.ConfigureOpenAPI();

    app.UseSwagger();
    app.UseSwaggerUI();

using(var scope= app.Services.CreateScope()){
    

    
    await DatabaseSeed.InitializeAsync(scope.ServiceProvider);


}

app.UseMiddleware<ErrorHandling>();




app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();


app.UseCors("Policy");

app.MapControllers();

app.Run();