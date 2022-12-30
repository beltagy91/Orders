namespace OrdersManager.Domain
{
    public class Order:BaseClass
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal  TotalAmount { get; set; }
        public int sa { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }

    }
}