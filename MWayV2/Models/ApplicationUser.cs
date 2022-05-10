using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string? user11 { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Budget> budgets { get; set; }

        public static implicit operator ApplicationUser(string v)
        {
            throw new NotImplementedException();
        }
    }
}
