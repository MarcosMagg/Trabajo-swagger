using Crud.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();




builder.Services.AddMvc()
    .AddJsonOptions(o => {
        o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
     });





string conecctionString = builder.Configuration.GetSection("ConnectionStrings").GetSection("Default").Value;

//int parametro = int parse(builder.Configuration.GetSection("parametroImportantr"));   ejemplo


builder.Services.AddDbContext<MARCOS_1Context>(config =>
{
    config.UseSqlServer(conecctionString);
});




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
