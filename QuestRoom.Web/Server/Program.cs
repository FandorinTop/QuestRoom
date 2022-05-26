using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess;
using QuestRoom.DataAccess.Repositories;
using QuestRoom.DataAccess.UnitOfWork;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

// Add services to the container.

InjectServices(builder.Services);
InjectRepository(builder.Services);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();
InitDb(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = ("swagger/docs");
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.ConfigureExceptionHandler(app.Environment, app.Logger);
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

static void InitDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        //Resolve ASP .NET Core Identity with DI hel
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        context.Database.EnsureCreated();
    }
}


void InjectServices(IServiceCollection service)
{
    service.AddTransient<IClientService, ClientService>();
    service.AddTransient<IDiscountService, DiscountService>();
    service.AddTransient<IPersonalService, PersonalService>();
    service.AddTransient<IPersonalTypeService, PersonalTypeService>();
    service.AddTransient<IQuestActorService, QuestActorService>();
    service.AddTransient<IQuestService, QuestService>();
    service.AddTransient<IQuestTypeNameService, QuestTypeNameService>();

    service.AddTransient<IQuestSessionService, QuestSessionService>();

}

void InjectRepository(IServiceCollection service)
{
    service.AddTransient<IDiscountRepository, DiscountRepository>();
    service.AddTransient<IPersonalRepository, PersonalRepository>();
    service.AddTransient<IPersonalTypeRepository, PersonalTypeRepository>();
    service.AddTransient<IQuestActorRepository, QuestActorRepository>();
    service.AddTransient<IQuestRepository, QuestRepository>();
    service.AddTransient<IQuestSessionRepository, QuestSessionRepository>();
    service.AddTransient<IQuestTypeNameRepository, QuestTypeNameRepository>();
    service.AddTransient<IClientRepository, ClientRepository>();
    service.AddTransient<IUnitOfWork, UnitOfWork>();
}

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;
                    var path = context.Request.Path;
                    var message = string.Empty;
                    var result = string.Empty;
                    dynamic response = null;

                    switch (exception)
                    {
                        case ServiceValidationException controllerException:
                            logger.LogError($"Invalid data Message: '{exception.Message}'");
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            message = exception.Message;
                            break;
                        default:
                            logger.LogError(exception, context.Request.Path);
                            message = exception.Message;
                            break;
                    }

                    if (env.EnvironmentName == "Test" || env.IsDevelopment())
                    {
                        response = new
                        {
                            StatusCode = context.Response.StatusCode,
                            ExMessage = message,
                            response,
                            exception
                        };
                    }
                    else
                    {
                        response = new
                        {
                            StatusCode = context.Response.StatusCode,
                            ExMessage = message,
                            response
                        };
                    }
                }
            });
        });
    }
}
