using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoCDemoLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }

        //Overriding EF default nullable field
        [Required]
        //Overriding EF default 'nvarchar(max)' with a lesser number of characters for performance purposes
        [MaxLength(200)]
        public string ProductName { get; set; }

        [MaxLength(200)]
        public string ProductNameSlug { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        //Not sure if a Product image stored as image in the db or should it be a string pointing to the file?
        public byte[] ProductImage { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public string ProductTypeName { get; set; }

        //Navigation property holding other entities (in this case ProductTypes) related to Product
        // According to MS Docs virtual key is needed to take advantage of certain EF functionalities such as 'lazy loading'
        public virtual List<ProductType> ProductTypes { get; set; }
    }
}
