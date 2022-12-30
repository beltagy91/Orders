using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrdersManager.Models.Enums;

namespace OrdersManager.Domain
{
    public class Customer:BaseClass
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Job { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}
