using Ankh_Morpork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnkhMorpork.MSTests
{
    [TestClass]
    public class UnitTest1
    {
        private Game _game;

        [TestInitialize]
        public void SetUp()
        {
            _game = new Game();
        }

        [TestMethod]
        [DataRow(100, 20, 120)]
        [DataRow(50, 13, 63)]
        public void Plus_WhenCalled_ReturnsTheSumOfTwoIntegers1(int a, int b, int expected)
        {
            var rezult = _game.Plus(a, b);

            Assert.AreEqual(expected, rezult);
        }


        [TestMethod]
        [DataRow(100, 20, 80)]
        [DataRow(25, 3, 22)]
        public void Minus_WhenCalled_ReturnsTheSumOfTwoIntegers1(int a, int b, int expected)
        {
            var rezult = _game.Minus(a, b);

            Assert.AreEqual(expected, rezult);
        }
    }
}
