using Article;
using Article.Data;
using Article.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ArticleIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ArticleIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<ArticleIdentityDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ArticleIdentityDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var sendGridKey = new Configuration.SendGridConfig();
app.Configuration.GetSection("SendGridKey").Bind(sendGridKey);
Configuration.SendGridKey = sendGridKey;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
