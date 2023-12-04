using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models
{
	public class Order
	{
		public int Id { get; set; }
		[ForeignKey("UserId")]
		public int UserId { get; set; }
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
