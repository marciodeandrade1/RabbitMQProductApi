using RabbitMQProductApi.Data;
using RabbitMQProductApi.Models;

namespace RabbitMQProductApi.Services
{
    public class ProductService : IProductService

    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result !=null ? true : false;
        }
        public Product GetProductById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }
        public Product GetProductByName(string name)
        {
            return _dbContext.Products.Where(x => x.ProductName == name).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
