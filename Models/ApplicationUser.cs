using Microsoft.AspNetCore.Identity;

namespace Article.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
}

