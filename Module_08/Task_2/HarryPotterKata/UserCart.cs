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
            var uniqueBooks = ReturnUniqueBooksList();
            decimal resultPrice = 0;

            foreach (var books in uniqueBooks)
            {
                var percent = ReturnDiscountPercent(books.Length);
                var price = books.Sum(s => s.Price);
                var discount = percent * price / 100;
                resultPrice += (price - discount);
            }

            return resultPrice;
        }

        private List<Book[]> ReturnUniqueBooksList()
        {
            var tempCart = new List<Book>();
            tempCart.AddRange(Cart);
            var uniqueBooks = new List<Book[]>();

            do
            {
                var books = tempCart.DistinctBy(b => b.Title).ToArray();
                uniqueBooks.Add(books);

                foreach (var book in books)
                {
                    tempCart.Remove(book);
                }
            } while (tempCart.Count > 0);

            return uniqueBooks;
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
