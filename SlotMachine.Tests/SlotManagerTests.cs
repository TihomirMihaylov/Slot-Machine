namespace SlotMachine.Tests
{
    public class SlotManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoWinningLines()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 1.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 1.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'P', 'P', 'P' }, //3 * 0.8
                { 'A', 'B', 'P' }
            };

            var expected = 2.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesAndOneLineOfBananasWin()
        {
            var matrix = new char[,]
            {
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 3;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesAndOneLineOfBananasAndOneLineOfPineapplesWin()
        {
            var matrix = new char[,]
            {
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'P', 'P', 'P' }, //3 * 0.8
                { 'A', 'B', 'P' }
            };

            var expected = 5.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ApplesEverywhereWin()
        {
            var matrix = new char[,]
            {
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'A', 'A', 'A' } //3 * 0.4
            };

            var expected = 4.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BananasEverywhereWin()
        {
            var matrix = new char[,]
            {
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'B', 'B', 'B' }, //3 * 0.6
                { 'B', 'B', 'B' } //3 * 0.6
            };

            var expected = 7.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PineapplesEverywhereWin()
        {
            var matrix = new char[,]
            {
                { 'P', 'P', 'P' }, //3 * 0.8
                { 'P', 'P', 'P' }, //3 * 0.8
                { 'P', 'P', 'P' }, //3 * 0.8
                { 'P', 'P', 'P' } //3 * 0.8
            };

            var expected = 9.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWithOneWildcardSymbolWins()
        {
            var matrix = new char[,]
            {
                { 'A', '*', 'A' }, //0.4 + 0 + 0.4
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 0.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWithOneWildcardSymbolWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { '*', 'B', 'B' }, //0 + 0.6 + 0.6
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 1.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWithOneWildcardSymbolWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'P', 'P', '*' }, //0.8 + 0.8 + 0
                { 'A', 'B', 'P' }
            };

            var expected = 1.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MixOfApplesBananasAndPineapplesWithOneWildcardSymbolEachWin()
        {
            var matrix = new char[,]
            {
                { 'A', '*', 'A' }, //0.4 + 0 + 0.4
                { '*', 'B', 'B' }, //0 + 0.6 + 0.6
                { 'P', 'P', '*' }, //0.8 + 0.8 + 0
                { 'A', 'B', 'P' }
            };

            var expected = 3.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWithTwoWildcardSymbolsWins()
        {
            var matrix = new char[,]
            {
                { '*', '*', 'A' }, //0 + 0 + 0.4
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 0.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWithTwoWildcardSymbolsWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { '*', 'B', '*' }, //0 + 0.6 + 0
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 0.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWithTwoWildcardSymbolsWins()
        {
            var matrix = new char[,]
            {
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'P', '*', '*' }, //0.8 + 0 + 0
                { 'A', 'B', 'P' }
            };

            var expected = 0.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MixOfApplesBananasAndPineapplesWithTwoWildcardSymbolsEachWin()
        {
            var matrix = new char[,]
            {
                { '*', '*', 'A' }, //0 + 0 + 0.4
                { '*', 'B', '*' }, //0 + 0.6 + 0
                { 'P', '*', '*' }, //0.8 + 0 + 0
                { 'A', 'B', 'P' }
            };

            var expected = 1.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfWildcardCharactersWinsZero()
        {
            var matrix = new char[,]
            {
                { '*', '*', '*' }, //3 * 0
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' },
                { 'A', 'B', 'P' }
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WildcardCharactersEverywhereWinZero()
        {
            var matrix = new char[,]
            {
                { '*', '*', '*' }, //3 * 0
                { '*', '*', '*' }, //3 * 0
                { '*', '*', '*' }, //3 * 0
                { '*', '*', '*' } //3 * 0
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleFromTheDocumentReturnsCorrectResult()
        {
            var matrix = new char[,]
            {
                { 'B', 'A', 'A' },
                { 'A', 'A', 'A' }, //3 * 0.4
                { 'A', '*', 'B' },
                { '*', 'A', 'A' } //0 + 0.4 + 0.4
            };

            var expected = 2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }
    }
}