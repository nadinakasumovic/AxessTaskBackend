using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Data
{
    [Table("Shippers")]
    public class ShipVia
    {
        [Column("ShipperID")]
        [Key]
        public int ShipViaID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
