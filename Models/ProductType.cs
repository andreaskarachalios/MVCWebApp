using System.Collections.Generic;

namespace ProductManager.Models {
    public partial class ProductType {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public partial class ProductType {
        public IList<Product> Products { get; } = new List<Product>();
        public bool CanBeRemoved { get => Products.Count == 0; }
    }
}