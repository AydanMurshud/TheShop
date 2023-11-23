using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
namespace DbLayer.Models;

public class Category : CategoryDto
{
	[Key]
	public int Id { get; set; }

	public List<Product>? Products { get; set; }
}

