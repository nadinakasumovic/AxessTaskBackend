using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Data
{
    [Table("Orders")]
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public Customer? Customer { get; set; }
        public string? CustomerID { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeID { get; set; }
        [ForeignKey("ShipViaID")]
        public ShipVia ShipVia { get; set; }
        [Column("ShipVia")]
        public int ShipViaID { get; set; }

    }
}
