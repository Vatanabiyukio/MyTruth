using HailOnDemilich.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string demilich = "Server=127.0.0.1;Database=DB_DEMILICH;User=root;Password=superidol;";
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(demilich, ServerVersion.AutoDetect(demilich)), ServiceLifetime.Transient);

const string formConnection = "data source=sqlserver.cassi.com.br;initial catalog=DB_FORM;user id=usrform;password=formprd123$";
// const string formConnection = "data source=sqlserver.hml.cassi.com.br;initial catalog=DB_FORM;user id=casrhoxsi;password=123@hml%";
builder.Services.AddDbContext<DbFormContext>(options =>
    options.UseSqlServer(formConnection), ServiceLifetime.Transient);

const string plntConnection = "data source=sqlserver.cassi.com.br;initial catalog=DB_PLNTO_EPS;user id=usreps;password=epsprd123$";
// const string plntConnection = "data source=sqlserver.hml.cassi.com.br;initial catalog=DB_PLNTO_EPS;user id=casrhoxsi;password=123@hml%";
builder.Services.AddDbContext<DbPlntoEpsContext>(options =>
    options.UseSqlServer(plntConnection), ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();