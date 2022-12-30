using OrdersManager.Models.Enums;

namespace OrdersManager.Models.SearchCriterias
{
    public class CustomerSearchCriteria
    {
        //search in (Customer name or job or address or phone or email)
        public string? FreeText { get; set; }

        public int? CustomerId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? NumberOfOrders { get; set; }
        public ComparisonOperator? NumberOfOrdersOperator { get; set; }
        public decimal? TotalOrdersAmount { get; set; }
        public ComparisonOperator? TotalOrdersAmountOperator { get; set; }


    }
}
