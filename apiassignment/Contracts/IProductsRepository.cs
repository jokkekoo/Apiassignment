namespace apiassignment.Contracts
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Products>> GetAll();
        public Task<IEnumerable<Products>> Get(int id);
        public Task<IEnumerable<Products>> Post(Products product);
        public Task<IEnumerable<Products>> GetProductManufacturer(string manufacturer);
        public Task<IEnumerable<Products>> Put(int id, string name);
        public Task<IEnumerable<Products>> Delete(int id);
    }
}
