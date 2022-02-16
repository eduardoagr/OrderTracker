using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }

    public enum ItemType
    {
        Grocery,
        GeneralMerch,
        Pharmaceutical
    }
}
