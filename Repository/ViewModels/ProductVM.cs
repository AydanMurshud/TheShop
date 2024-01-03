using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.ViewModels
{
	public class ProductVM
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
		[ForeignKey("PromotionId")]
		public Guid? PromotionId { get; set; }
		public Guid? CategoryId { get; set; }
	}
}
