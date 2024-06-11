
using Microsoft.EntityFrameworkCore;
using TripleA.Core;
using TripleA.Infrustructure;
using TripleA.Infrustructure.Context;
using TripleA.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureDependencies()
        .AddServiceDependencies()
        .AddCoreDependencies()
        ;

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
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
