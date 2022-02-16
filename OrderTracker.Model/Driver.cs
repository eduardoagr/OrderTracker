using System;
using System.ComponentModel.DataAnnotations;

namespace OrderTracker.Model {
    public class Driver {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
