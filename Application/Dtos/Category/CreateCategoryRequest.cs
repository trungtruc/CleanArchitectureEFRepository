using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.Category
{
    public class CreateCategoryRequest
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
