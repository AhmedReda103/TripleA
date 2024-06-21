using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TripleA.Core;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure;
using TripleA.Infrustructure.Context;
using TripleA.Infrustructure.seeder;
using TripleA.Service;
using TripleA.Service.implementations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureDependencies()
        .AddServiceDependencies()
        .AddCoreDependencies()
        .AddServiceRegisteration(builder.Configuration).AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://127.0.0.1:5500", "http://localhost:4200") //add your origin here
                         .AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowCredentials();  //for signalR requests
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}



app.UseCors("MyPolicy");

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<RealTimeService>("/notificationHub");

app.Run();
