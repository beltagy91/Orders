using AutoMapper;
using Azure;
using OrdersManager.Controllers.Interfaces;
using OrdersManager.Domain;
using OrdersManager.Models.Dtos;
using OrdersManager.Models.SearchCriterias;
using OrdersManager.Orchestrators.Interfaces;
using OrdersManager.Repositories;

namespace OrdersManager.Orchestrators
{
    public class CustomerOrch : ICustomerOrch
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomerOrch(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public List<CustomerDto> Get(CustomerSearchCriteria criteria)
        {
            List<Customer> customers = new List<Customer>();
            var customersQuerable = _customerRepository.GetAsQueryable(criteria);

            var customerDtos = customersQuerable.Select(sub => _mapper.Map<CustomerDto>(sub)).ToList();
            return customerDtos;

        }
    }
}
