using backend1.Data;
using backend1.Data.Repository;
using backend1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IChildService, ChildService>();
builder.Services.AddTransient<IChildrenWithCourageAppRepository, ChildrenWithCourageAppRepository>();

builder.Services.AddAutoMapper(typeof(Program));
//entity framework config
var connectionString = builder.Configuration.GetConnectionString("ChildrenWithCourageConnectionString");
builder.Services.AddDbContext<ChildrenWithCourageDBContext>(x => x.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
