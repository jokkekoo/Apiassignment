using apiassignment.Context;
using apiassignment.Contracts;
using Dapper;

namespace apiassignment.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly DapperContext _context;
        public ManufacturerRepository(DapperContext context)
        {
            _context = context;
        }
        // Get all Manufacturers
        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            var query = "SELECT * FROM Manufacturers";

            using(var connection = _context.CreateConnection())
            {
                var manufacturers = await connection.QueryAsync<Manufacturer>(query);
                return manufacturers.ToList();
            }
        }

        // Get specific Manufacturer by Id
        public async Task<IEnumerable<Manufacturer>> Get(int id)
        {
            var query = "SELECT Manufacturer_Name FROM Manufacturers WHERE ID_Manufacturer =" + id;

            using (var connection = _context.CreateConnection())
            {
                var manufacturers = await connection.QueryAsync<Manufacturer>(query);
                return manufacturers.ToList();
            }
        }

        // Create new Manufacturer
        public async Task<IEnumerable<Manufacturer>> Post(Manufacturer manufacturer)
        {
            var query = "INSERT INTO Manufacturers (Manufacturer_Name) VALUES ('" + manufacturer.Manufacturer_Name + "')";
            using (var connection = _context.CreateConnection())
            {
                var isOK = await connection.QueryAsync<Manufacturer>(query);
                return isOK.ToList();
            }
        }
        // Update Manufacturer By Id and providing a new name
        public async Task<IEnumerable<Manufacturer>> Put(int id, string name)
        {
            var query = "UPDATE Manufacturer SET Manufacturer_Name = '" + name + "' WHERE ID_Products = " + id;

            using (var connection = _context.CreateConnection())
            {
                var isOK = await connection.QueryAsync<Manufacturer>(query);
                return isOK.ToList();
            }
        }

        // Delete Manufacturer by Id
        public async Task<IEnumerable<Manufacturer>> Delete(int id)
        {
            var query = "DELETE FROM Manufacturer WHERE ID_Manufacturer =" + id;

            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Manufacturer>(query);
                return products.ToList();
            }
        }
    }
}
