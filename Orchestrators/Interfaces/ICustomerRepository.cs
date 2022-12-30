using OrdersManager.Domain;
using OrdersManager.Models.SearchCriterias;

namespace OrdersManager.Orchestrators.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IQueryable<Customer> GetAsQueryable(CustomerSearchCriteria criteria);

    }
}
