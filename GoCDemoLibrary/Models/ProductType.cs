using System.ComponentModel.DataAnnotations;

namespace GoCDemoLibrary.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        //Overriding EF default 'nvarchar(max)' with a lesser number of characters for performance purposes
        [MaxLength(50)]
        public string ProductTypeName { get; set; }
    }
}
