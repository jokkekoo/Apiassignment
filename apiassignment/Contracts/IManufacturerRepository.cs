namespace apiassignment.Contracts
{
    public interface IManufacturerRepository
    {
        public Task<IEnumerable<Manufacturer>> GetAll();
        public Task<IEnumerable<Manufacturer>> Get(int id);
        public Task<IEnumerable<Manufacturer>> Post(Manufacturer manufacturer);
        public Task<IEnumerable<Manufacturer>> Put(int id, string name);
        public Task<IEnumerable<Manufacturer>> Delete(int id);

    }
}
