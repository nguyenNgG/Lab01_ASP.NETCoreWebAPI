#nullable disable

using System.Runtime.Serialization;

namespace DTOs
{
    [DataContract]
    public partial class ProductDTO
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public int? CategoryId { get; set; }

        [DataMember]
        public short? UnitsInStock { get; set; }

        [DataMember]
        public decimal? UnitPrice { get; set; }

        public virtual CategoryDTO Category { get; set; }
    }
}
