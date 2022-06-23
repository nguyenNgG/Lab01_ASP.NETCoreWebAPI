using System.Collections.Generic;
using System.Runtime.Serialization;

#nullable disable

namespace DTOs
{
    [DataContract]
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            Products = new HashSet<ProductDTO>();
        }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
