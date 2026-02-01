using Microsoft.AspNetCore.Identity;

namespace CustomMembershipSample.Data;

public class ApplicationUser : IdentityUser
{
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
}
