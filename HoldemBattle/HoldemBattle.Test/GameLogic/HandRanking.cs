using System;
using System.Collections.Generic;
using HoldemBattle.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoldemBattle.Test
{
    /// <summary>
    /// Tests of the HandRanking class and functionality.
    /// </summary>
    [TestClass]
    public class HandRanking
    {
        /// <summary>
        /// In a list of <see cref="Card"/> objects representing a straight, it's correctly determined.
        /// </summary>
        [TestMethod]
        public void ValidStraightDetected()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Four),
                new Card(GameValues.Suit.Club, GameValues.Value.Five),
                new Card(GameValues.Suit.Club, GameValues.Value.Six),
                new Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "A straight was not determined succesfully.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects with no straight, it's correctly ignored.
        /// </summary>
        [TestMethod]
        public void InvalidStraightIgnored()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Four),
                new Card(GameValues.Suit.Club, GameValues.Value.Five),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
                new Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
            };

            Assert.IsNull(GameLogic.HandRanking.ContainsStraight(cards), "A straight was detected, though it shouldn't have been.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects with almost a straight, it's correctly ignored.
        /// </summary>
        [TestMethod]
        public void FourStraightIgnored()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Four),
                new Card(GameValues.Suit.Club, GameValues.Value.Five),
                new Card(GameValues.Suit.Club, GameValues.Value.Six),
                new Card(GameValues.Suit.Club, GameValues.Value.Seven),
            };

            Assert.IsNull(GameLogic.HandRanking.ContainsStraight(cards), "A straight was detected, though it shouldn't have been.");
        }

        /// <summary>
        /// In a long list of <see cref="Card"/> objects with a long straight, the highest value of the straight is found.
        /// </summary>
        [TestMethod]
        public void HighestValueInLongStraight()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Four),
                new Card(GameValues.Suit.Club, GameValues.Value.Five),
                new Card(GameValues.Suit.Club, GameValues.Value.Six),
                new Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);

            Assert.IsNotNull(topValue, "A straight was not determined succesfully.");
            Assert.AreEqual(GameValues.Value.Nine, topValue);
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects with the lowest possible straight, it is determined correctly.
        /// </summary>
        [TestMethod]
        public void LowestAceStraightDetected()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new Card(GameValues.Suit.Club, GameValues.Value.Two),
                new Card(GameValues.Suit.Club, GameValues.Value.Three),
                new Card(GameValues.Suit.Club, GameValues.Value.Four),
                new Card(GameValues.Suit.Club, GameValues.Value.Five),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "A 5-high straight was not determined succesfully.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects with the highest possible straight, it is determined correctly.
        /// </summary>
        [TestMethod]
        public void HighestAceStraightDetected()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
                new Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new Card(GameValues.Suit.Club, GameValues.Value.Two),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "An ace-high straight was not determined succesfully.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects where in the middle of the straight, there's a paired card, it is determined correctly.
        /// </summary>
        [TestMethod]
        public void PairingInStraightIgnored()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
                new Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new Card(GameValues.Suit.Club, GameValues.Value.Queen),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "An ace-high straight was not determined succesfully.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects, a straight is detected when they are intentionally out of order.
        /// </summary>
        [TestMethod]
        public void IndependantOfInputOrdering()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new Card(GameValues.Suit.Club, GameValues.Value.King),
                new Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new Card(GameValues.Suit.Club, GameValues.Value.Queen),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "An ace-high straight was not determined succesfully.");
        }
    }
}
