using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace TaskAPI.Data
{
    [Table("Employees")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public string PhotoPath { get; set; }
        [ForeignKey("ReportsToID")]
        public Employee? ReportsTo { get; set; }
        [Column("ReportsTo")]
        public int? ReportsToID { get; set; }
        [NotMapped]
        public string Base64String
        {
            get
            {
                var base64Str = string.Empty;
                using (var ms = new MemoryStream())
                {
                    int offset = 78;
                    ms.Write(Photo, offset, Photo.Length - offset);
                    var bmp = new System.Drawing.Bitmap(ms);
                    using (var jpegms = new MemoryStream())
                    {
                        bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        base64Str = Convert.ToBase64String(jpegms.ToArray());
                    }
                }
                return base64Str;
            }
        }
    }
}
