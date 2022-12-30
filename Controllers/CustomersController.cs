using Microsoft.AspNetCore.Mvc;
using OrdersManager.Controllers.Interfaces;
using OrdersManager.Models.Dtos;
using OrdersManager.Models.SearchCriterias;
using OrdersManager.Orchestrators;

namespace OrdersManager.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerOrch _customerOrch;

        public CustomersController(ICustomerOrch customerOrch)
        {
            _customerOrch = customerOrch;
        }

        [HttpPost]
        public ActionResult<List<CustomerDto>> Get([FromBody] CustomerSearchCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest();
            }
            else
            { 
                var result = _customerOrch.Get(criteria);
                return Ok(result);
            }
        }
    }
}
