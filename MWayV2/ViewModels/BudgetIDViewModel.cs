using MWayV2.Models;

namespace MWayV2.ViewModels
{
    public class BudgetIDViewModel
    {
        public IQueryable<Budget>? Budgets { get; set; }
        public Budget Budget { get; set; }
        public string UserId { get; set; }

    }
}
