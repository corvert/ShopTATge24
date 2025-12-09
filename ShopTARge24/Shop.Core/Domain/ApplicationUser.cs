using Microsoft.AspNetCore.Identity;

namespace Shop.Core.Domain
{
    // Ensure you have installed the Microsoft.AspNetCore.Identity.EntityFrameworkCore NuGet package
    // If not, run: dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string Name { get; set; }
    }
}
