using Microsoft.EntityFrameworkCore;
using YourScheduler.BusinessLogic.Initialization;
using YourScheduler.Infrastructure;
using YourScheduler.Infrastructure.Initialization;
using YourScheduler.Infrastructure.Entities;
using AutoMapper;
using YourScheduler.WebApplication.Middlewares;
using YourScheduler.BusinessLogic.Services.Settings;
using Microsoft.OpenApi.Models;
using NuGet.Configuration;
using Microsoft.AspNetCore.Identity;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("YourSchedulerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YourSchedulerDbContextConnection' not found.");

var configuration = new ConfigurationBuilder()
   .SetBasePath(builder.Environment.ContentRootPath)
   .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
   .Build();

builder.Services.AddOptions();

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
    })
    .AddIdentityCookies(cookies => });



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentityCore<ApplicationUser>(options => 
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedAccount = false; 
})
 .AddEntityFrameworkStores<YourSchedulerDbContext>()
 .AddRoles<IdentityRole>()
 .AddRoleManager<RoleManager<IdentityRole>>()
 .AddSignInManager<ApplicationUser>()
 .AddUserManager<ApplicationUser>()
 .AddDefaultTokenProviders();

builder.Services.AddInfrastructureDependencies(builder.Configuration);


builder.Services.AddAuthorization();

builder.Services.AddBusinessLogicDependencies();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
            },
            new List <string> ()
        }
    });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/authorize"),
                TokenUrl = new Uri("https://login.microsoftonline.com/common/common/v2.0/token"),
            }
        }
    });
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true);
    //options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowCredentials();  
        });

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();


app.Run();

