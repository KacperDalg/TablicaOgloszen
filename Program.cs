using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Data;
using TablicaOgloszen.DatabaseOperations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NoticeBoardDBContext>(options =>
    options.UseSqlServer("Data Source=NoticeBoard.db"));
builder.Services.BuildServiceProvider().GetService<NoticeBoardDBContext>().Database.Migrate();
builder.Services.AddScoped<IAdRepository, AdRepository>();
builder.Services.AddControllersWithViews();
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