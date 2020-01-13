namespace ProductManager.Models {
    public partial class Product {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public partial class Product {
        public ProductType Type { get; set; }
    }
}