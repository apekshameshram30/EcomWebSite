using Application.Interface;
using Domain.Entity;
using ECom.Implementation;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Twilio.Clients;
using Web.Implementation;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//automapper injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();

//database configuration
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
dbContextOptions.UseSqlServer(
        builder.
        Configuration.GetConnectionString("ConStr"),
        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));




var configuration = builder.Configuration;

var emailConfig = configuration.GetSection("EmailConfiguration")
                               .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

//var stripeConfig = configuration.GetSection("StripeConfiguration").Get<StripeSettings>();
//services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IImageFile, ImageFile>();
builder.Services.AddScoped<IStripeService, StripeService>();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSetting"));

builder.Services.AddHttpClient<ITwilioRestClient, TwilioClient>();

//Db Context injection
builder.Services
    .AddScoped<IApplicationDbContext>(
    provider => provider.GetRequiredService<ApplicationDbContext>()
    );

//mediatR injection
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

//frontend connectivity
builder.Services.AddCors(options =>
{
    options.AddPolicy("Alloworigin",
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowedToAllowWildcardSubdomains());
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Alloworigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
