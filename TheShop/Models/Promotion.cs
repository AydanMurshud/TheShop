namespace TheShop.Models
{
	public class Promotion
	{
		public int Id { get; set; }
		public string PromotionName { get; set; }
		public int PromotionRate { get; set; }
		public List<Product> Products { get; set; }
	}
}
