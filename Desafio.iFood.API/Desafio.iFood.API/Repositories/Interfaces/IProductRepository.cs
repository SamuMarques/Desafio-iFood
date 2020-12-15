using Desafio.iFood.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.iFood.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task Delete(int id);
    }
}
