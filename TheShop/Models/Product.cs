using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheShop.Models
{
	public class Product : ProductBaseModel
	{
		[Key]
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } 
		public DateTime UpdatedAt { get; set; }
		
	}
}
