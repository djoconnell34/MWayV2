using Microsoft.AspNetCore.Identity;

namespace MWayV2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string? AddressStreet { get; set; }

        public string? AddressCity { get; set; }

        public string? AddressZip { get; set; }

        public string? WorkStreet { get; set; }

        public string? WorkCity { get; set; }

        public string? WorkZip { get; set; }

        public byte[]? ProfilePicture { get; set; }
    }
}
