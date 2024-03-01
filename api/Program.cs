using System.Reflection;
using Admin;
using Common;
using FluentValidation;
using Hangfire;
using infrutructure;
using infrutructure.Authorization.Handler;
using infrutructure.Authorization.Provider;
using infrutructure.Seed;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using RealTime.Notifications.Admin;
using Repository;
using schoolmanagment.Base;
using schoolmanagment.Middleware;
using Shared.Jwt;
using Shared.Redis;
using Shared.Services.Email;
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
builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationPolicyProvider,PermissionProvider>();
builder.Services.AddTransient<IAuthorizationHandler,PermissionAuthorizationHandler>();

builder.Services.AddScoped<IMailService, MailService>();
// end api area     


builder.Services.Configure<MailSetting>(builder.Configuration.GetRequiredSection("Email"));

builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddHangfireServer();


builder.Services.AddSignalR(option =>
{

    option.EnableDetailedErrors = true;
});



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

app.MapHub<AdminHub>("/admin");

app.MapControllers();

app.Run();