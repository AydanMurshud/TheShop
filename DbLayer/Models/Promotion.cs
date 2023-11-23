namespace DbLayer.Models;

public class Promotion :PromotionDto
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
}
