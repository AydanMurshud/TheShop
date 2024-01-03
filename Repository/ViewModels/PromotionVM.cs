using DbLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ViewModels
{
	public class PromotionVM
	{
		public string PromotionName { get; set; }
		public int PromotionRate { get; set; }
		public List<Product> Products { get; set; }
	}
}
