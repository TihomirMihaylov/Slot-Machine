using SlotMachine.Models;

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
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 1.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 1.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() }, //3 * 0.8
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 2.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesAndOneLineOfBananasWin()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 3;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesAndOneLineOfBananasAndOneLineOfPineapplesWin()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() }, //3 * 0.8
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 5.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ApplesEverywhereWin()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() } //3 * 0.4
            };

            var expected = 4.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BananasEverywhereWin()
        {
            var matrix = new Symbol[,]
            {
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() }, //3 * 0.6
                { new BananaSymbol(), new BananaSymbol(), new BananaSymbol() } //3 * 0.6
            };

            var expected = 7.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PineapplesEverywhereWin()
        {
            var matrix = new Symbol[,]
            {
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() }, //3 * 0.8
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() }, //3 * 0.8
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() }, //3 * 0.8
                { new PineappleSymbol(), new PineappleSymbol(), new PineappleSymbol() } //3 * 0.8
            };

            var expected = 9.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWithOneWildcardSymbolWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new WildcardSymbol(), new AppleSymbol() }, //0.4 + 0 + 0.4
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWithOneWildcardSymbolWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new WildcardSymbol(), new BananaSymbol(), new BananaSymbol() }, //0 + 0.6 + 0.6
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 1.2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWithOneWildcardSymbolWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new PineappleSymbol(), new PineappleSymbol(), new WildcardSymbol() }, //0.8 + 0.8 + 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 1.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MixOfApplesBananasAndPineapplesWithOneWildcardSymbolEachWin()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new WildcardSymbol(), new AppleSymbol() }, //0.4 + 0 + 0.4
                { new WildcardSymbol(), new BananaSymbol(), new BananaSymbol() }, //0 + 0.6 + 0.6
                { new PineappleSymbol(), new PineappleSymbol(), new WildcardSymbol() }, //0.8 + 0.8 + 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 3.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfApplesWithTwoWildcardSymbolsWins()
        {
            var matrix = new Symbol[,]
            {
                { new WildcardSymbol(), new WildcardSymbol(), new AppleSymbol() }, //0 + 0 + 0.4
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0.4;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfBananasWithTwoWildcardSymbolsWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new WildcardSymbol(), new BananaSymbol(), new WildcardSymbol() }, //0 + 0.6 + 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0.6;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfPineapplesWithTwoWildcardSymbolsWins()
        {
            var matrix = new Symbol[,]
            {
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new PineappleSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //0.8 + 0 + 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MixOfApplesBananasAndPineapplesWithTwoWildcardSymbolsEachWin()
        {
            var matrix = new Symbol[,]
            {
                { new WildcardSymbol(), new WildcardSymbol(), new AppleSymbol() }, //0 + 0 + 0.4
                { new WildcardSymbol(), new BananaSymbol(), new WildcardSymbol() }, //0 + 0.6 + 0
                { new PineappleSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //0.8 + 0 + 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 1.8;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneLineOfWildcardSymbolactersWinsZero()
        {
            var matrix = new Symbol[,]
            {
                { new WildcardSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //3 * 0
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() },
                { new AppleSymbol(), new BananaSymbol(), new PineappleSymbol() }
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WildcardSymbolactersEverywhereWinZero()
        {
            var matrix = new Symbol[,]
            {
                { new WildcardSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //3 * 0
                { new WildcardSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //3 * 0
                { new WildcardSymbol(), new WildcardSymbol(), new WildcardSymbol() }, //3 * 0
                { new WildcardSymbol(), new WildcardSymbol(), new WildcardSymbol() } //3 * 0
            };

            var expected = 0;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleFromTheDocumentReturnsCorrectResult()
        {
            var matrix = new Symbol[,]
            {
                { new BananaSymbol(), new AppleSymbol(), new AppleSymbol() },
                { new AppleSymbol(), new AppleSymbol(), new AppleSymbol() }, //3 * 0.4
                { new AppleSymbol(), new WildcardSymbol(), new BananaSymbol() },
                { new WildcardSymbol(), new AppleSymbol(), new AppleSymbol() } //0 + 0.4 + 0.4
            };

            var expected = 2;
            var actual = SlotManager.CalculateWinnings(matrix, 1);
            Assert.AreEqual(expected, actual);
        }
    }
}