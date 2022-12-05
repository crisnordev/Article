using Microsoft.AspNetCore.Identity;

namespace Article.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public override string UserName { get; set; } = string.Empty;

    public override string NormalizedUserName => UserName.ToUpper();
}

