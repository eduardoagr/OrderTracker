using OrderTracker.Model;

using System.Linq;

namespace OrderTracker.Data {
    public interface IUnitOfWork {
        public bool AddCustomer(Customer customer);
        public IQueryable<Customer> GetCustomerById(int id);
        public bool AddManufacturer(string name);

        public bool AddItem(string itemName, ItemType itemType, int manufacturerId);

        public bool AddDirver(Driver driver);

        public bool RemoveDriver(Driver driver);

        public bool UpdateDiver(Driver driver);

        public IQueryable<Driver> GetDriverById(int id);
    }
}
