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
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            Cart.Add(book);
        }

        public decimal CalculateDiscount()
        {
            var uniqueBooks = Cart.DistinctBy(b => b.Title).Count();

            var resultPrice = Cart.Sum(book => book.Price);

            var percent = ReturnDiscountPercent(uniqueBooks);
            var discount = percent * resultPrice / 100;

            return discount == 0 ? resultPrice : resultPrice - discount;
        }

        private decimal ReturnDiscountPercent(int count)
        {
            return count switch
            {
                2 => 5,
                3 => 10,
                4 => 20,
                5 => 25,
                _ => 0
            };
        }
    }
}
