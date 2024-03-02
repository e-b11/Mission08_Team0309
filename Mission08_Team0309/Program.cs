using Microsoft.EntityFrameworkCore;
using Mission08_Team0309;
using Mission08_Team0309.Models;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ToDoListContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:ToDoConnection"]);
});
    

// For some reason the above code wasn't working ^ 
// So ChatGPT gave me this and it worked:
//builder.Services.AddDbContext<ToDoListContext>(options =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
//    options.UseSqlite(connectionString);
//});


builder.Services.AddScoped<IToDoListRepository, EFToDoListRepository>();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
