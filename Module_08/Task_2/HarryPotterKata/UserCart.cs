namespace HarryPotterKata
{
    public class UserCart
    {
        public List<Book> Cart;

        public UserCart()
        {
            Cart = new List<Book>();
        }

        public void AddToCart(Book book)
        {
            Cart.Add(book);
        }

        public decimal CalculateDiscount()
        {
            decimal resultPrice = default;

            foreach (Book book in Cart)
            {
                resultPrice += book.Price;
            }

            return resultPrice;
        }
    }
}
