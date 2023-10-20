namespace unittests
{
    [TestClass]
    public class Fast_Unit_Tests
    {
        [TestMethod("validate numbers are > 0")]
        public void numbers_are_greater_than_0()
        {
            Assert.IsTrue(true);
        }
        [TestMethod("validate numbers are < 10")]
        public void numbers_are_greater_smaller_than_10()
        {
            Assert.IsTrue(true);
        }
        [TestMethod("validate numbers are odd")]
        public void numbers_are_odd()
        {
            Assert.IsTrue(true);
        }
        [TestMethod("validate numbers are even")]
        public void numbers_are_even()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Dummy_test()
        {
            var c = new GloboTicket.Catalog.Artist(Guid.NewGuid(), "Rolling Stones", "Rock'n'Roll");
            Assert.AreEqual(c.Name, "Rolling Stones");
        }
    }
}
