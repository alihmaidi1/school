using System.Reflection;
using Common;
using FluentValidation;
using Hangfire;
using infrastructure;
using infrastructure.Authorization.Handler;
using infrastructure.Authorization.Provider;
using infrastructure.Seed;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Newtonsoft.Json.Converters;
using Schoolmanagment.Base;
using schoolmanagment.Middleware;
using Shared.Entity.Interface;
using Shared.Jwt;
using Shared.Services.Email;
using Shared.Swagger;
using infrastructure.BackgroundJob;

var builder = WebApplication.CreateBuilder(args);

#region MainConfiguration
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});
builder.Services.AddResponseCompression(option => { option.MimeTypes = new[] { "application/json" }; });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddHangfireServer();
#endregion


#region CommonConfiguration

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Scan(selector =>
    selector
        .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
        .AddClasses(c => c.AssignableTo(typeof(IBaseSuper)))
        .AsSelfWithInterfaces()
        .WithScopedLifetime()
        .AddClasses(c=>c.AssignableTo(typeof(IBaseSuperTransient)))
        .AsSelfWithInterfaces()
        .WithTransientLifetime()
        .AddClasses(c=>c.AssignableTo(typeof(IBaseSuperSingleTon)))
        .AsSelfWithInterfaces()
        .WithSingletonLifetime());

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;



#endregion


#region SharedConfiguration

builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.Configure<MailSetting>(builder.Configuration.GetRequiredSection("Email"));
#endregion


#region securityConfiguration

builder.Services.AddTransient<IAuthorizationPolicyProvider,PermissionProvider>();
builder.Services.AddTransient<IAuthorizationHandler,PermissionAuthorizationHandler>();

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

builder.Services.AddRateLimiter(rateLimiterOptions =>
{

    rateLimiterOptions.AddFixedWindowLimiter("fixedwindow", option =>
    {

        option.PermitLimit = 2;
        option.Window=TimeSpan.FromSeconds(1);
        option.QueueLimit = 0;
    });


});

#endregion

// builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();

// end api area     





// builder.Services.AddSignalR(option =>
// {
//
//     option.EnableDetailedErrors = true;
// });



// common area

builder.Services.AddCommondependency();

// end common area



// infrustucture area
builder.Services.AddInfrustucture(builder.Configuration);

// end infrustucture area





// shared area

// end shared area






builder.Services.AddOpenApi(Assembly.GetExecutingAssembly().GetName().Name??"");


var app = builder.Build();

app.ConfigureOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();

using(var scope= app.Services.CreateScope()){
    

    
    await DatabaseSeed.InitializeAsync(scope.ServiceProvider);



}

app
.Services
.GetRequiredService<IRecurringJobManager>()
.AddOrUpdate<ProcessOutboxMessageJob>("outbox-message",x=>x.Process(),Cron.Minutely());

app.UseMiddleware<ErrorHandling>();


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();
app.UseHangfireDashboard("/hangfire/dashboard");

app.UseCors("Policy");

// app.MapHub<AdminHub>("/admin");

app.MapControllers();

app.Run();