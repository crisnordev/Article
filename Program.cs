using Article;
using Article.Data;
using Article.Models;
using Article.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ArticleIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<ArticleIdentityDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ArticleIdentityDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

var sendGridKey = new Configuration.SendGridConfig();
app.Configuration.GetSection("SendGridKey").Bind(sendGridKey);
Configuration.SendGridKey = sendGridKey;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
