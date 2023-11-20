﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheShop.Models
{
	public class ProductBaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
		[ForeignKey("PromotionId")]
		public int? PromotionId { get; set; }
		public int? CategoryId { get; set; }

	}
}