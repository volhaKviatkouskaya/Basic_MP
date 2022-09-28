namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            Product product = obj as Product;
            var result = this.Name == product.Name && this.Price == product.Price;

            return result;
        }
    }
}
