﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Class03.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Class03Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Class03Context") ?? throw new InvalidOperationException("Connection string 'Aula04_EWPL1_Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ad service to the new class DbInitializer
builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DbInitializer>();
//execute the method Run from the class DbInitializer
initializer.Run();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}");

app.Run();
