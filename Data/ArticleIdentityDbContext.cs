using Article.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Article.Data;

public class ArticleIdentityDbContext : 
    IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ArticleIdentityDbContext(
        DbContextOptions<ArticleIdentityDbContext> options)
        : base(options)
    {
    }
}