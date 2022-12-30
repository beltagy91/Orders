using LinqKit;
using OrdersManager.Data;
using OrdersManager.Domain;
using OrdersManager.Models.Enums;
using OrdersManager.Models.SearchCriterias;
using OrdersManager.Orchestrators.Interfaces;

namespace OrdersManager.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrdersManagerDbContext context) : base(context)
        {

        }
        public IQueryable<Customer> GetAsQueryable(CustomerSearchCriteria criteria)
        {
            var outerpredicate = PredicateBuilder.New<Customer>(true);

            var inner = PredicateBuilder.New<Customer>(true);
            if (!string.IsNullOrWhiteSpace(criteria.FreeText))
            {
                criteria.FreeText = criteria.FreeText.ToLower().Trim();
                inner = inner.Or(x => x.Name.ToLower().Trim().Contains(criteria.FreeText));
                inner = inner.Or(x => x.Email.ToLower().Trim().Contains(criteria.FreeText));
                inner = inner.Or(x => x.Phone.ToLower().Trim().Contains(criteria.FreeText));
                inner = inner.Or(x => x.Job.ToLower().Trim().Contains(criteria.FreeText));
                inner = inner.Or(x => x.Address.ToLower().Trim().Contains(criteria.FreeText));
            }

            if (criteria.CustomerId != null)
                outerpredicate.And(c=>c.Id==criteria.CustomerId);

            if (criteria.DateOfBirth != null)
                outerpredicate.And(c => c.DateOfBirth == criteria.DateOfBirth);

            if (criteria.NumberOfOrders!=null && criteria.NumberOfOrdersOperator !=null)
            {
                switch (criteria.NumberOfOrdersOperator)
                {
                    case ComparisonOperator.Equal:
                        outerpredicate.And(c => c.Orders.Count == criteria.NumberOfOrders);
                        break;
                    case ComparisonOperator.GreaterThan:
                        outerpredicate.And(c => c.Orders.Count > criteria.NumberOfOrders);
                        break;
                    case ComparisonOperator.LessThan:
                        outerpredicate.And(c => c.Orders.Count < criteria.NumberOfOrders);
                        break;
                    default:
                        break;
                }
            }

            if (criteria.TotalOrdersAmount != null && criteria.TotalOrdersAmountOperator != null)
            {
                switch (criteria.TotalOrdersAmountOperator)
                {
                    case ComparisonOperator.Equal:
                        outerpredicate.And(c => c.Orders.Sum(o=>o.TotalAmount) == criteria.TotalOrdersAmount);
                        break;
                    case ComparisonOperator.GreaterThan:
                        outerpredicate.And(c => c.Orders.Sum(o => o.TotalAmount) > criteria.TotalOrdersAmount);
                        break;
                    case ComparisonOperator.LessThan:
                        outerpredicate.And(c => c.Orders.Sum(o => o.TotalAmount) < criteria.TotalOrdersAmount);
                        break;
                    default:
                        break;
                }
            }






            outerpredicate = outerpredicate.And(inner);

            return this.Get(outerpredicate);
        }
    }
}
