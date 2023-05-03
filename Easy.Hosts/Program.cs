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

WebApplicationBuilder builder = WebApplication.CreateBuilder();
{
    builder.Services.AddDbContext<EasyHostsDbContext>();

    builder.Services.AddScoped<EasyHostsDbContext>();

    builder.Services.AddIdentity<User, IdentityRole>()
                 .AddEntityFrameworkStores<EasyHostsDbContext>()
                 .AddDefaultTokenProviders();

    builder.Services.AddScoped<IBedroomService, BedroomService>();
    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<IEventService, EventService>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<ITypeBedroomService, TypeBedroomService>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddCors();
    builder.Services.AddControllers();

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Default Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;
    });

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Easy.Hosts API",
            Description = "Project Fatec Guaratinguetá",
        });
    });
};

WebApplication app = builder.Build();
{
    app.UseHttpLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "APISaudacao v1");
    });

    app.UseCors(builder =>
      builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.UseAuthentication();
    app.MapControllers();
    app.Run();
};
