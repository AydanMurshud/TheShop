using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
namespace DbLayer.Models;

public class Category
{
	[Key]
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Image { get; set; }
	public List<Product>? Products { get; set; }
}

