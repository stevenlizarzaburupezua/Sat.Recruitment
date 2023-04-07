using Autofac;
using Autofac.Core;
using ParamoTech.SatRecruitment.Application.Implementation;
using ParamoTech.SatRecruitment.Application.Interface;
 
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 

builder.Services.AddScoped<IUsersService, UsersService>();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(DocExpansion.None);
        c.SwaggerEndpoint("v1/swagger.json", "Tipo Cambio v1");
    });

}

app.UseAuthorization();

app.MapControllers();

app.Run();


