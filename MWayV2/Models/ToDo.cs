using System.ComponentModel.DataAnnotations;

namespace MWayV2.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }
        public string ToDoName { get; set; } = "";
        public string? ToDoDescription { get; set; }
        public bool ToDoIsComplete { get; set; } = false;
        public string IdHolder { get; set; }
    }
}
