using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dtos.Category;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<Category> GetCategoryByIdAsync(int id);
        Task AddAsync(CreateCategoryRequest request);
    }
}
