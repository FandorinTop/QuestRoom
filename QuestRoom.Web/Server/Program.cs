using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess;
using QuestRoom.DataAccess.Repositories;
using QuestRoom.DataAccess.UnitOfWork;
using QuestRoom.Interfaces.Repositories;
using QuestRoom.Interfaces.Services;
using QuestRoom.Interfaces.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


void InjectServices(IServiceCollection service)
{
    service.AddTransient<IClientService, ClientService>();
    service.AddTransient<IDiscountService, DiscountService>();
    service.AddTransient<IPersonalService, PersonalService>();
    service.AddTransient<IPersonalTypeService, PersonalTypeService>();
    service.AddTransient<IQuestActorService, QuestActorService>();
    service.AddTransient<IQuestService, QuestService>();
    service.AddTransient<IQuestTypeNameService, QuestTypeNameService>();
    service.AddTransient<IQuestTypeService, QuestTypeService>();

    //service.AddTransient<IQuestActorSetService, QuestActorSetService>();
    //service.AddTransient<IQuestSessionService, QuestSessionService>();

}

void InjectRepository(IServiceCollection service)
{
    service.AddTransient<IDiscountRepository, DiscountRepository>();
    service.AddTransient<IPersonalRepository, PersonalRepository>();
    service.AddTransient<IPersonalTypeRepository, PersonalTypeRepository>();
    service.AddTransient<IQuestActorRepository, QuestActorRepository>();
    service.AddTransient<IQuestActorSetRepository, QuestActorSetRepository>();
    service.AddTransient<IQuestRepository, QuestRepository>();
    service.AddTransient<IQuestSessionRepository, QuestSessionRepository>();
    service.AddTransient<IQuestTypeRepository, QuestTypeRepository>();
    service.AddTransient<IQuestTypeNameRepository, QuestTypeNameRepository>();
    service.AddTransient<IClientRepository, IClientRepository>();
    service.AddTransient<IUnitOfWork, UnitOfWork>();
}