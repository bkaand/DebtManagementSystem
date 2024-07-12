using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string ClientName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastLoginDate { get; set; }
}
