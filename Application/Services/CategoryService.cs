using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dtos.Category;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }
        public async Task AddAsync(CreateCategoryRequest request)
        {
            Category category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = string.Empty,
                CreatedDate = DateTime.Now                
            };
            await _categoryRepository.AddAsync(category);
        }
        public async Task UpdateAsync(Category category)
        {

        }
    }
}
