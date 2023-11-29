﻿using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDBContext _context;
		public CategoryRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(CategoryDto entity)
		{
			var category = new Category
			{
				Title = entity.Title,
				Image = entity.Image
			};
			_context.Category.Add(category);
			return Save();
		}
		public bool Delete(Category entity)
		{
			_context.Remove(entity);
			return Save();
		}
		public async Task<IEnumerable<Category>> GetAll(string? searchTerm, string? deep)
		{
			if (deep != null && deep == "true")
			{
				if (searchTerm != null) return await _context.Category.Where(c => c.Title.Contains(searchTerm)).Include(c => c.Products).ToListAsync();
				return await _context.Category.Include(cat => cat.Products).ToListAsync();
			}
			else
			{
				if (searchTerm != null) return await _context.Category.Where(c => c.Title.Contains(searchTerm)).ToListAsync();
				return await _context.Category.ToListAsync();
			}
		}
		public async Task<Category> GetById(int? Id)
		{
			return await _context.Category.Include(cat => cat.Products).FirstOrDefaultAsync(cat => cat.Id == Id);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(Category entity, CategoryDto update)
		{
			entity.Title = update.Title;
			entity.Image = update.Image;
			_context.Update(entity);
			return Save();
		}
	}
}
