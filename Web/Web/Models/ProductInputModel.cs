using System.Collections.Generic;

namespace Web.Models
{
    public class ProductInputModel
    {
        public string Name { get; set; }
             
        public string Description { get; set; }

        public decimal Price { get; set; }
            
        public string PhotoFileName { get; set; }
    }
}