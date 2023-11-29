namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private UniversityLibrary testLibrary;
        private TextBook testBook;
        [SetUp]
        public void Setup()
        {
            testLibrary = new();
            testBook = new("TestTitle", "TestAuthor", "Drama");
        }

        [Test]
        public void ListInitializesCorrectly()
        {
            Assert.IsNotNull(testLibrary);
        }
        [Test]
        public void AddTextBookMethodWorksCorrrectly()
        {
            testLibrary.AddTextBookToLibrary(testBook);

            Assert.AreEqual(testLibrary.Catalogue.Count, 1);
        }
        [Test]
        public void BookInventoryNumberWorksCorrectly()
        {
            Assert.AreEqual(testBook.InventoryNumber, 0);
        }
        [Test]
        public void LoandedBookNotReturnedReturnMessage()
        {
            testBook.Holder = "John";
            testLibrary.AddTextBookToLibrary(testBook);

            Assert.AreEqual(testLibrary.LoanTextBook(1, "John"), "John still hasn't returned TestTitle!");
        }
        [Test]
        public void LoandedBookSuccessfully()
        {
            testLibrary.AddTextBookToLibrary(testBook);

            Assert.AreEqual(testLibrary.LoanTextBook(1, "John"), "TestTitle loaned to John.");
        }
        [Test]
        public void ReturningABookGetsRidOfHolder()
        {
            testLibrary.AddTextBookToLibrary(testBook);
            testLibrary.LoanTextBook(1, "John");
            testLibrary.ReturnTextBook(1);

            Assert.AreEqual(testBook.Holder, string.Empty);
        }

        [Test]
        public void ReturningBookSuccessfullMessage()
        {
            testLibrary.AddTextBookToLibrary(testBook);
            testLibrary.LoanTextBook(1, "John");

            Assert.AreEqual(testLibrary.ReturnTextBook(1), "TestTitle is returned to the library.");
        }
    }
}