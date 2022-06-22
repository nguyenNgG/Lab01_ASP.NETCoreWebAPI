using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfMyStoreService
{
    [DataContract]
    public class Product
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

        public virtual Category Category { get; set; }
    }
}
