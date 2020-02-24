using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Product Image")]
        public string Image { get; set; }

        [Required]
        /*
        // have to run and check if this regex works
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Price must contain numbers only")]
        */
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        public float Price { get; set; }

        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created on")]
        public DateTime ProdAddDate = DateTime.Now;
    }

    public class ProductsDBContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}
