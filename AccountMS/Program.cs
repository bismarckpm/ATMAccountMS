using AccountMS.Application.Handlers.Commands;
using AccountMS.Core.Database;
using AccountMS.Core.Repositories;
using AccountMS.Infrastructure.Database;
using AccountMS.Infrastructure.Repositories;
using AccountMS.Infrastructure.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var _appSettings = new AppSettings();
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
_appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.Configure<AppSettings>(appSettingsSection);

builder.Services.AddMediatR(typeof(CreateAccountCommandHandler).Assembly);
builder.Services.AddTransient<IAccountDbContext, AccountDbContext>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

var dbConnectionString = builder.Configuration.GetValue<string>("DBConnectionString");
builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseNpgsql(dbConnectionString));

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
