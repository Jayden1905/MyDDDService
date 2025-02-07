using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDDDService.src.Domain.Entities;

namespace MyDDDService.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetByID(int id);
        IEnumerable<Product> GetAll();

        void Add(Product product);
    }
}
