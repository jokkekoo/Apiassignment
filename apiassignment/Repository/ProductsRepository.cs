using apiassignment.Context;
using apiassignment.Contracts;
using Dapper;

namespace apiassignment.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DapperContext _context;
        public ProductsRepository(DapperContext context)
        {
            _context = context;
        }

        // Get all products
        public async Task<IEnumerable<Products>> GetAll()
        {
            var query = "SELECT * FROM Products";

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Products>(query);
                return products.ToList();
            }
        }
        // Get product by id
        public async Task<IEnumerable<Products>> Get(int id)
        {
            var query = "SELECT Product_Name, Description FROM Products WHERE ID_Products =" + id;

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Products>(query);
                return products.ToList();
            }
        }
        // Add a new product
        public async Task<IEnumerable<Products>> Post(Products product)
        {
            var query = "INSERT INTO Products (ID_Manufacturer, Product_Name, Description) VALUES (" + product.ID_Manufacturer + ",'" + product.Product_Name + "', '" + product.Description + "')";

            using (var connection = _context.CreateConnection()) 
            {
                var isOK = await connection.QueryAsync<Products>(query);
                return isOK.ToList();
            }
        }
        // Change products name
        public async Task<IEnumerable<Products>> Put(int id, string name)
        {
            var query = "UPDATE Products SET Product_Name = '" + name + "' WHERE ID_Products = " + id;

            using (var connection = _context.CreateConnection()) 
            {
                var isOK = await connection.QueryAsync<Products>(query);
                return isOK.ToList();
            }
        }

        // Get Products with Manufacturer name
        public async Task<IEnumerable<Products>> GetProductManufacturer(string manufacturer)
        {
            var query = "SELECT Manufacturer_Name, Product_name, Description FROM Products INNER JOIN Manufacturers ON Products.ID_Manufacturer = Manufacturers.ID_Manufacturer WHERE Manufacturer_Name='" + manufacturer + "'";

            using (var connection = _context.CreateConnection())
            {
                var productmanufacturer = await connection.QueryAsync<Products>(query);
                return productmanufacturer.ToList();
            }
        }
        // Delete product by id
        public async Task<IEnumerable<Products>> Delete(int id)
        {
            var query = "DELETE FROM Products WHERE ID_Products =" + id;

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Products>(query);
                return products.ToList();
            }
        }
    }
}
