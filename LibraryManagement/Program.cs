using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models.Domain;
using LibraryManagement.Repositories.Abstract;
using LibraryManagement.Repositories.Implementation;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
