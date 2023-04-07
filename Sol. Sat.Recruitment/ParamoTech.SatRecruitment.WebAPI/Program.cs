using Autofac;
using Autofac.Core;
using Microsoft.OpenApi.Models;
using ParamoTech.SatRecruitment.Application.Implementation;
using ParamoTech.SatRecruitment.Application.Interface;
using ParamoTech.SatRecruitment.Infrastructure;
using ParamoTech.SatRecruitment.WebAPI.Infrastructure;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(HttpGlobalExceptionFilter));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ParamoTech",
        Description = "API for Sat.Recruitment"
    });

});


builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUsersInfrastructureService, UsersInfrastructureService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(DocExpansion.None);
        c.SwaggerEndpoint("v1/swagger.json", "IServiceCollection v1");
    });

}

app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

