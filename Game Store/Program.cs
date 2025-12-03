using System;
using Game_Store;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGameStoreServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHsts();// Enforce HTTP Strict Transport Security
//app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseStaticFiles(); 
app.UseRouting(); // Choose endpoint based on request
app.UseAuthentication(); // Reading Identity Cookies
app.UseAuthorization(); // Check user permissions
app.MapControllers();// Map attribute routed controllers
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
