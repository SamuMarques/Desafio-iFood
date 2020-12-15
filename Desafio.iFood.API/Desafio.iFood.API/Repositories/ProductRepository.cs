using Desafio.iFood.API.Domain;
using Desafio.iFood.API.Infrastructure;
using Desafio.iFood.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.iFood.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> Create(Product product)
        {
            try
            {
                _dataContext.Products.Add(product);
                await _dataContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                //rollback
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Product>> Get()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dataContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                _dataContext.Products.Update(product);
                await _dataContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                //Rollback
                throw ex;
            }
        }
    }
}
