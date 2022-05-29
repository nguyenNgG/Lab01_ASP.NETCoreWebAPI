using System;
using System.Collections.Generic;

#nullable disable

namespace DTOs
{
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            Products = new HashSet<ProductDTO>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
