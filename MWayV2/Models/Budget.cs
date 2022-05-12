using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace MWayV2.Models
{
    public class Budget
    {
        [Key]
        public int BudgetItemID { get; set; }
        
        public int? BudgetGroupId { get; set; }
        
        public string? BudgetGroup { get; set; }
        [Required]
        public string? BudgetItemName { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required]
        public double? BudgetItemCost { get; set; }
        
        public string? MonthlyYearly { get; set; }

        public string? IdHolder { get; set; }




        [ForeignKey("Id")]
        [InverseProperty("budgets")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
