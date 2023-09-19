using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Initialization;
using YourScheduler.BusinessLogic.Models;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Initialization;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.BusinessLogic.Services.Settings;
using FluentAssertions.Common;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("YourSchedulerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YourSchedulerDbContextConnection' not found.");


builder.Services.AddDbContext<YourSchedulerDbContext>(options =>
 options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Facebook:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Facebook:ClientSecret"];
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
    

var emailConfig = builder.Configuration.GetSection("MailSettings").Get<MailSettings>();
builder.Services.AddSingleton(emailConfig);



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
 .AddEntityFrameworkStores<YourSchedulerDbContext>();

builder.Services.AddInfrastructureDependencies(builder.Configuration);


builder.Services.AddAuthorization();

builder.Services.AddBusinessLogicDependencies();

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
app.UseStaticFiles();

app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

app.Run();

