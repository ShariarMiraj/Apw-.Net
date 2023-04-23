using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(15)]
        public string ProductCategory {get; set; }
        [Required]
        [StringLength(10)]
        public string ProductPrice { get; set; }
        [Required]
        [StringLength(15)]
        public string ProdcutQuantity { get; set; }
        [ForeignKey("Seller")]
        public string SelleingBy { get; set; }

        public virtual Seller Seller { get; set; }

    }
}
