using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok();
        }
    }
}
