using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDDDService.Domain.Repositories;
using MyDDDService.src.Domain.Entities;

namespace MyDDDService.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void CreateProduct(int id, string name, decimal price)
        {
            var product = new Product(id, name, price);
            _repository.Add(product);
        }

        public Product GetProductByID(int id)
        {
            var product = _repository.GetByID(id);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _repository.GetAll();
            return products;
        }
    }
}
