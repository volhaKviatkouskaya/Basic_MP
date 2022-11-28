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
                new("Harry Potter and the Sorcerer’s Stone", 1),
                new("Harry Potter and the Chamber of Secrets", 2),
                new(" Harry Potter and the Prisoner of Azkaban", 3),
                new("Harry Potter and the Goblet of Fire", 4),
                new("Harry Potter and the Order of the Phoenix", 5),
                new("Harry Potter and the Half-Blood Prince", 6),
                new("Harry Potter and the Deathly Hallows", 7),
                new("Harry Potter and the Cursed Child", 8)
            };
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(8, 8)]
        public void Check_Number_Of_Books(int insertion, int expected)
        {
            //Arrange
            var userCart = new UserCart();
            var count = 0;

            //Act
            foreach (var book in _testBooks)
            {
                if (count < insertion)
                {
                    userCart.AddToCart(book);
                }

                count++;
            }
            var actual = userCart.Cart.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}