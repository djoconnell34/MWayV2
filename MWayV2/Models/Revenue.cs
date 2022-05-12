using System.ComponentModel.DataAnnotations;

namespace MWayV2.Models
{
    public class Revenue
    {
        [Key]
        public int RevenueId { get; set; }
        public string? IncomeName { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Income { get; set; }
        public string? IncomeMonthlyYearly { get; set; }
        public string? IdHolder { get; set; }
    }
}
