using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data;

public class AppUser : IdentityUser
{
    public DateTime BirthDate { get; set; }
}