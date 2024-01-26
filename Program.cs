using Auth_Jwt.Helpers;
using Auth_Jwt.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IUserRepository, UserRepository>();

//add Authentication
//Google
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
        {
            options.ClientId = "412804632746-ti3kd7rvpal6hdub4frof5l7hqf3ih4v.apps.googleusercontent.com";
            options.ClientSecret = "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";
            // options.ClientId = "XXXXXXXXXXXXXXXXXXX";
            // options.ClientSecret = "XXXXXXXXXXXXXXXXXXXXXXX";
        });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

//Use Authentication and Authorization
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
