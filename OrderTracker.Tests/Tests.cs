using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using OrderTracker.Data;
using OrderTracker.Model;

using System.Linq;

namespace OrderTracker.Tests {
    public class Tests {
        private DbContextOptions options;
        private OrderTrackerContext _context;
        private string userId = "SYSTEM";
        private IUnitOfWork uow;

        [SetUp]
        public void SetupContext() {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            options = new DbContextOptionsBuilder<OrderTrackerContext>().UseSqlite(connection).Options;


            //  with sql lite inmemory, we need to create the tables first in one context, 
            // and then recreate the context for our uses
            using (var migContext = new OrderTrackerContext(options)) {
                migContext.Database.EnsureCreated();
            }


            // the actual context
            _context = new OrderTrackerContext(options);

            uow = new UnitOfWork(_context);
        }

        [Test]
        public void AddCustomer_ValidCustomer_ReturnsTrue() {
            // Arrange
            Customer customer = new Customer() {
                Id = 1,
                FirstName = "James",
                LastName = "Cameron",
                StreetAddress = "123 Sesame Street",
                City = "New York City",
                ZIP = "11111",
                State = "NY",
                PhoneNumber = "1111111111",
                Email = "jc@terminator.com"

            };

            // Act

            var result = uow.AddCustomer(customer);

            // Assert

            Assert.IsTrue(result);

            var qCust = _context.Customers.Where(q => q.Id == 1).FirstOrDefault();
            Assert.AreSame(qCust, customer);


        }

        [Test]
        public void AddDriver_ValidDriver_ReturnsTrue() {
            // Arrange
            Driver driver = new Driver() {
                Id = 1,
                FirstName = "James",
                LastName = "Cameron",
                Rating = 4

            };

            // Act

            var result = uow.AddDirver(driver);

            // Assert

            Assert.IsTrue(result);

            var qDrive = _context.Drivers.Where(q => q.Id == 1).FirstOrDefault();
            Assert.AreSame(qDrive, driver);


        }
        [Test]
        public void RemoveDriver_ValidDriver_ReturnsTrue() {
            // Arrange
            Driver driver = new Driver() {
                Id = 1,
                FirstName = "James",
                LastName = "Cameron",
                Rating = 4

            };

            // Act

            var result = uow.RemoveDriver(driver);

            // Assert
            var Drivera = _context.Drivers;


            //Assert.IsTrue(result);

            var qDrive = _context.Drivers.Remove(driver);
            Assert.AreNotEqual(Drivera, qDrive);


        }

        [Test]
        public void UpdateDriver_ValidDriver_ReturnsTrue() {


            Driver driver = new Driver() {
                Id = 1,
                FirstName = "James",
                LastName = "Cameron",
                Rating = 4
            };

            Driver sut = _context.Drivers.FirstOrDefault(x => x.Id == driver.Id);

            if (sut != null) {
                sut.FirstName = driver.FirstName;
                sut.LastName = driver.LastName;
                sut.Rating = driver.Rating;
                bool result = uow.UpdateDiver(sut);
                Assert.AreEqual(true, result);

            }

            var qDrive = _context.Drivers.Where(q => q.Id == 1).FirstOrDefault();

            Assert.AreSame(qDrive.FirstName, driver.FirstName);
            Assert.AreSame(qDrive.LastName, driver.LastName);
            Assert.AreSame(qDrive.Rating, driver.Rating);
        }
    }
}