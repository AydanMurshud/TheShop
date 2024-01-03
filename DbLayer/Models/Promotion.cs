namespace DbLayer.Models;

public class Promotion
{
    public Guid Id { get; set; }
	public string PromotionName { get; set; }
	public int PromotionRate { get; set; }
	public List<Product> Products { get; set; }
}
