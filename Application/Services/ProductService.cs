using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRepository<ProductLog> _productLogRepository;        

        public ProductService(IProductRepository productRepository, IRepository<ProductLog> productLogRepository)
        {
            _productRepository = productRepository;
            _productLogRepository = productLogRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(int id) =>
            await _productRepository.GetProductByIdAsync(id);

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            ProductLog productLog = new ProductLog()
            {
                ProductId = product.Id,
                Action = "Create",
                Changes = $"Product {product.Name} was created.",
                Timestamp = DateTime.Now
            };
            await _productLogRepository.AddAsync(productLog);
        }            

        public async Task UpdateProductAsync(Product product) =>
            await _productRepository.UpdateAsync(product);

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
            }
        }
    }
}
