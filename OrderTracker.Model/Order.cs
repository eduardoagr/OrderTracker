using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTracker.Model {
    public class Order {

        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
