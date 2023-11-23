namespace DbLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        List<Product> Orders { get; set; }
    }
}
