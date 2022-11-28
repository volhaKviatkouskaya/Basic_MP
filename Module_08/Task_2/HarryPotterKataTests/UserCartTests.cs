using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarryPotterKata.Tests
{
    [TestClass]
    public class UserCartTests
    {
        private List<Book> _testBooks;

        [TestInitialize]
        public void SetUp()
        {
            _testBooks = new List<Book>()
            {
                new("Harry Potter and the Sorcerer’s Stone", 8),
                new("Harry Potter and the Chamber of Secrets", 8),
                new(" Harry Potter and the Prisoner of Azkaban", 8),
                new("Harry Potter and the Goblet of Fire", 8),
                new("Harry Potter and the Order of the Phoenix", 8),
                new("Harry Potter and the Half-Blood Prince", 8),
                new("Harry Potter and the Deathly Hallows", 8),
                new("Harry Potter and the Cursed Child", 8)
            };
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(8, 8)]
        public void Check_Number_Of_Books(int insertion, int expected)
        {
            var userCart = new UserCart();
            var count = 0;

            foreach (var book in _testBooks)
            {
                count++;
                if (count <= insertion)
                {
                    userCart.AddToCart(book);
                }
            }
            var actual = userCart.Cart.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(null, 0)]
        public void Should_Throw_ArgumentNullException(Book itemBook, int expected)
        {
            var userCart = new UserCart();

            Assert.ThrowsException<ArgumentNullException>(() => userCart.AddToCart(itemBook));
            Assert.AreEqual(expected, userCart.Cart.Count);
        }

        [TestMethod]
        [DataRow(1, 8)]
        [DataRow(2, 16)]
        [DataRow(3, 24)]
        public void User_Have_No_Discount(int insertion, double expected)
        {
            var userCart = new UserCart();
            var testBook = _testBooks[insertion];
            var count = 0;

            do
            {
                userCart.AddToCart(testBook);
                count++;
            } while (count != insertion);

            var actual = userCart.CalculateDiscount();

            Assert.AreEqual((decimal)expected, actual);
        }

        [TestMethod]
        [DataRow(1, 1, 2, 22.8)]
        [DataRow(1, 2, 2, 22.8)]
        public void User_Have_Five_Percent_Discount(int bookIndex1, int bookIndex2, int bookIndex3, double expected)
        {
            var userCart = new UserCart();
            userCart.AddToCart(_testBooks[bookIndex1]);
            userCart.AddToCart(_testBooks[bookIndex2]);
            userCart.AddToCart(_testBooks[bookIndex3]);

            var actual = userCart.CalculateDiscount();

            Assert.AreEqual((decimal)expected, actual);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 3, 30.4)]
        public void User_Have_Ten_Percent_Discount(int bookIndex1, int bookIndex2, int bookIndex3, int bookIndex4, double expected)
        {
            var userCart = new UserCart();

            userCart.AddToCart(_testBooks[bookIndex1]);
            userCart.AddToCart(_testBooks[bookIndex2]);
            userCart.AddToCart(_testBooks[bookIndex3]);
            userCart.AddToCart(_testBooks[bookIndex4]);

            var actual = userCart.CalculateDiscount();

            Assert.AreEqual((decimal)expected, actual);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 25.6)]
        public void User_Have_Twenty_Percent_Discount(int bookIndex1, int bookIndex2, int bookIndex3, int bookIndex4, double expected)
        {
            var userCart = new UserCart();

            userCart.AddToCart(_testBooks[bookIndex1]);
            userCart.AddToCart(_testBooks[bookIndex2]);
            userCart.AddToCart(_testBooks[bookIndex3]);
            userCart.AddToCart(_testBooks[bookIndex4]);

            var actual = userCart.CalculateDiscount();

            Assert.AreEqual((decimal)expected, actual);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4, 5, 30.0)]
        public void User_Have_Twenty_Five_Percent_Discount(int bookIndex1, int bookIndex2, int bookIndex3, int bookIndex4,
                                                            int bookIndex5, double expected)
        {
            var userCart = new UserCart();

            userCart.AddToCart(_testBooks[bookIndex1]);
            userCart.AddToCart(_testBooks[bookIndex2]);
            userCart.AddToCart(_testBooks[bookIndex3]);
            userCart.AddToCart(_testBooks[bookIndex4]);
            userCart.AddToCart(_testBooks[bookIndex5]);

            var actual = userCart.CalculateDiscount();

            Assert.AreEqual((decimal)expected, actual);
        }
    }
}