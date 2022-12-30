using OrdersManager.Domain;
using OrdersManager.Models.Dtos;
using OrdersManager.Models.SearchCriterias;

namespace OrdersManager.Controllers.Interfaces
{
    public interface ICustomerOrch
    {
        List<CustomerDto> Get(CustomerSearchCriteria criteria);

    }
}
