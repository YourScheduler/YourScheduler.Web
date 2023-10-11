using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Initialization;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Initialization;
using YourScheduler.Infrastructure.Entities;
using AutoMapper;
using YourScheduler.WebApplication.Middlewares;
using YourScheduler.BusinessLogic.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("YourSchedulerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YourSchedulerDbContextConnection' not found.");

var configuration = new ConfigurationBuilder()
   .SetBasePath(builder.Environment.ContentRootPath)
   .AddJsonFile("appsettings.Developement.json", optional: true, reloadOnChange: true)
   .Build();

builder.Services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

builder.Services.AddDbContext<YourSchedulerDbContext>(options =>
 options.UseSqlServer(connectionString));

builder.Services.AddControllers();


builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Facebook:ClientId"] ?? throw new Exception("ClientId for Facebook is null");
        options.ClientSecret = builder.Configuration["Authentication:Facebook:ClientSecret"] ?? throw new Exception("ClientSecret for Facebook is null"); ;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? throw new Exception("ClientId for Google is null");
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("ClientSecret for Google is null");
    });



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

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthentication();;

app.UseAuthorization();

app.MapControllers();

var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

app.Run();

