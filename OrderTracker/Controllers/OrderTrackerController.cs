using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OrderTracker.Data;
using OrderTracker.Model;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderTracker.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase {


        private readonly ILogger<OrderTrackerController> _logger;
        private string userId = "SYSTEM";
        private IUnitOfWork uow;

        public OrderTrackerController(ILogger<OrderTrackerController> logger, IUnitOfWork _uow) {
            _logger = logger;

            try {
                uow = _uow;
            } catch (Exception ex) {

                throw;
            }
        }


        /// <summary>
        /// Gets a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomersById/{id}")]
        public IQueryable<Customer> GetCustomerById(int id) {

            var result = uow.GetCustomerById(id);
            return result;
        }


        /// <summary>
        /// Adds a hardcoded customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer")]
        public bool AddHardCodedCustomer() {
            Customer customer = new Customer() {

                FirstName = "George",
                LastName = "Lucas",
                StreetAddress = "123 Sesame Street",
                City = "New York City",
                ZIP = "11111",
                State = "NY",
                PhoneNumber = "1111111111",
                Email = "gl@skyguy.com"

            };

            var result = uow.AddCustomer(customer);

            return result;
        }

        /// <summary>
        /// Adds a manufacturer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddManufacturer")]
        public bool AddManufacturer(string name) {
            var result = uow.AddManufacturer(name);

            return result;
        }


        /// <summary>
        /// Adds an item
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemType"></param>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddItem")]
        public bool AddItem(string itemName, ItemType itemType, int manufacturerId) {
            var result = uow.AddItem(itemName, itemType, manufacturerId);

            return result;
        }


        /// <summary>
        /// Adds a driver
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDriver")]
        public bool AddDriver(Driver driver) {
            var result = uow.AddDriver(driver);

            return result;
        }


        /// <summary>
        /// Gets a driver by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDriverById/{id}")]
        public IQueryable<Driver> GetDriverById(int id) {

            var result = uow.GetDriverById(id);
            return result;
        }

    }
}
