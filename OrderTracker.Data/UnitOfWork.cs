using OrderTracker.Model;
using System;
using System.Linq;

namespace OrderTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private OrderTrackerContext _context;

        public UnitOfWork(OrderTrackerContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool AddDriver(Driver driver)
        {
            try
            {
                _context.Drivers.Add(driver);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool RemoveDriver(Driver driver)
        {
            try
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool UpdateDriver(Driver driver)
        {
            try
            {
                _context.Drivers.Update(driver);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public IQueryable<Customer> GetCustomerById(int id)
        {
            return _context.Customers.Where(c => c.Id == id);
        }

        public bool AddItem(string itemName, ItemType itemType, int manufacturerId)
        {
            try
            {
                if (_context.Manufacturers.Where(m => m.Id == manufacturerId).Count() == 1
                    && _context.Items.Where(i => i.Name == itemName && i.ManufacturerId == manufacturerId).Count() == 0
                    )
                {
                    Item item = new Item()
                    {
                        Name = itemName,
                        ItemType = itemType,
                        ManufacturerId = manufacturerId
                    };

                    _context.Add(item);
                    _context.SaveChanges();
                    
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }

        public bool AddManufacturer(string name)
        {
            if (_context.Manufacturers.Where(m => m.Name == name).Count() > 0)
            {
                return false;
            }

            Manufacturer manufacturer = new Manufacturer()
            {
                Name = name
            };

            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();

            return true;
        }

       
    }
}
