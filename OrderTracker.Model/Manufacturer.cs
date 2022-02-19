using System.Collections.Generic;

namespace OrderTracker.Model {
    public class Manufacturer {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
