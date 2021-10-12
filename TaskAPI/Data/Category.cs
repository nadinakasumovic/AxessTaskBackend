using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace TaskAPI.Data
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [NotMapped]
        public string Base64String
        {
            get
            {
                var base64Str = string.Empty;
                using (var ms = new MemoryStream())
                {
                    int offset = 78;
                    ms.Write(Picture, offset, Picture.Length - offset);
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
