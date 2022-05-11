using MWayV2.Models;

namespace MWayV2.ViewModels
{
    public class BudgetRevenueViewModel
    {
        public IQueryable<Budget>? Budgets { get; set; }
        public IQueryable<Revenue>? Revenues { get; set; }

        public string? IncomeName { get; set; }
        public double? Income { get; set; }
        public string? IncomeMonthlyYearly { get; set; }
  

        public int? BudgetGroupId { get; set; }
        public string? BudgetGroup { get; set; }
        public string? BudgetItemName { get; set; }
        public double? BudgetItemCost { get; set; }
        public string? MonthlyYearly { get; set; }



        public string? IdHolder { get; set; }

    }
}
