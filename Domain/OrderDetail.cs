namespace OrdersManager.Domain
{
    public class OrderDetail:BaseClass
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
    }
}