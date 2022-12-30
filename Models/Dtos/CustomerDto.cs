using AutoMapper;
using OrdersManager.Domain;
using Web.Mappings;

namespace OrdersManager.Models.Dtos
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>();
        }
    }
}
