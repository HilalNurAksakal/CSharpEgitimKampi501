using CSharpEgitimKampi501.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task CreatProductAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task CreatProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultProductDto>> GelAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByProductIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
