using MWayV2.Models;

namespace MWayV2.ViewModels
{
    public class ToDoUserInfo
    {

        public IQueryable<ToDo>? todo { get; set; }
        public IQueryable<ApplicationUser>? user { get; set; }


        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string? AddressStreet { get; set; }

        public string? AddressCity { get; set; }

        public string? AddressState { get; set; }

        public string? AddressZip { get; set; }

        public string? WorkStreet { get; set; }

        public string? WorkCity { get; set; }

        public string? WorkState { get; set; }

        public string? WorkZip { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public string? user11 { get; set; }

        public int ToDoId { get; set; }
        public string ToDoName { get; set; } = "";
        public string? ToDoDescription { get; set; }
        public bool ToDoIsComplete { get; set; } = false;

    }
}
