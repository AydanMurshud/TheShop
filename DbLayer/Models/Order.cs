﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DbLayer.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		[ForeignKey("UserId")]
		public Guid UserId { get; set; }
		public List<Product> Products { get; set; } = new List<Product>();
	}
}
