using Microsoft.EntityFrameworkCore;
using YuvarajAPI.Data;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database Connection:

//Inmemory Databasee
//builder.Services.AddDbContext<YuvarajAPIDBContext>(options => options.UseInMemoryDatabase("YuvarajsDb"));

//Sql Server Database
builder.Services.AddDbContext<YuvarajAPIDBContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("YuvarajsAPIConnectionString")));//SQL connection need to change

//Middlewares
var app = builder.Build();

//Configure - HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
