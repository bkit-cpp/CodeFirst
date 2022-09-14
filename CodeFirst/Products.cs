using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Name Product is Required")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = " Price is Required")]
        public decimal price { get; set; }
        [Required(ErrorMessage ="Qty is Required")]
        public int Qty { get; set; }

        public string Remarks { get; set; }

    }
    public class EFCodeFirstEntities : DbContext
    { 
        public DbSet<Products> myproducts { get; set; }
    }

}