using OrderTracker.Data;
using OrderTracker.Model;
using System;

namespace OrderTracker.Controllers
{
    public class OrderTrackerController
    {
        private OrderTrackerContext _context;
        private string userId = "SYSTEM";
        private IUnitOfWork uow;

        public OrderTrackerController()
        {

            try
            {
                _context = new OrderTrackerContext(false);

                uow = new UnitOfWork(_context);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Customer GetCustomerById(int id)
        {
            return uow.GetCustomerById(id);
        }
    }
}
