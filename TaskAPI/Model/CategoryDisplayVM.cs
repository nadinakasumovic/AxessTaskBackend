using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Model
{
    public class CategoryDisplayVM
    {
        public List<Row> Categories { get; set; }
        public class Row
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public byte[] Picture { get; set; }
        }
    }
}
