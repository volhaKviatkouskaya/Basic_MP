namespace HarryPotterKata
{
    public class UserCart
    {
        public List<Book> Cart;
        private const string FivePercent = "5";
        private const string TenPercent = "10";
        private const string TwentyPercent = "20";
        private const string TwentyFivePercent = "25";

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

            var percent = decimal.Parse(ReturnDiscountPercent(uniqueBooks));
            var discount = percent * resultPrice / 100;

            return discount == 0 ? resultPrice : resultPrice - discount;
        }

        private string ReturnDiscountPercent(int count)
        {
            return count switch
            {
                2 => FivePercent,
                3 => TenPercent,
                4 => TwentyPercent,
                5 => TwentyFivePercent,
                _ => "0"
            };
        }
    }
}
