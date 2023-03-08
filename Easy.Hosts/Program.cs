using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using Easy.Hosts.Core.Service.Entities;
using Easy.Hosts.Core.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EasyHostsDbContext>();

builder.Services.AddIdentity<User, IdentityRole>()
             .AddEntityFrameworkStores<EasyHostsDbContext>();

builder.Services.AddScoped<IBedroomService, BedroomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITypeBedroomService, TypeBedroomService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddCors(option => {
    option.AddPolicy("AllowSpecificOrigin", policy => policy.WithOrigins("http://localhost:3000"));
    option.AddPolicy("AllowGetMethod", policy => policy.WithMethods("GET"));
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Easy.Hosts", Description = "API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISaudacao v1");
});


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
