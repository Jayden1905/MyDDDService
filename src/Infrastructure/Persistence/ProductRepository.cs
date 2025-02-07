using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDDDService.Domain.Repositories;
using MyDDDService.src.Domain.Entities;

namespace MyDDDService.src.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public Product GetByID(int id)
        {
            var product =
                _products.FirstOrDefault(p => p.Id == id)
                ?? throw new KeyNotFoundException($"Product with Id {id} not found.");
            return product;
        }

        public void Add(Product product) => _products.Add(product);

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
