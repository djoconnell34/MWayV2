namespace MWayV2.ViewModels
{
    public class BudgetToDo
    {


        public int BudgetItemID { get; set; }

        public int? BudgetGroupId { get; set; }

        public string? BudgetGroup { get; set; }

        public string? BudgetItemName { get; set; }

        public double? BudgetItemCost { get; set; }

        public string? MonthlyYearly { get; set; }

        public string? IdHolder { get; set; }






        public int ToDoId { get; set; }
        public string ToDoName { get; set; } = "";
        public string? ToDoDescription { get; set; }
        public bool ToDoIsComplete { get; set; } = false;
    }
}
