﻿//-----------------------------------------------------------------------
// <copyright file="HandRanking.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Test
{
    using System.Collections.Generic;

    using HoldemBattle.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests of the HandRanking class and functionality.
    /// </summary>
    [TestClass]
    public sealed class HandRanking
    {
        /// <summary>
        /// In a list of <see cref="Card"/> objects representing a straight, it's correctly determined.
        /// </summary>
        [TestMethod]
        public void ValidStraightDetected()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Four),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Six),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
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
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Four),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
            };

            Assert.IsNull(GameLogic.HandRanking.ContainsStraight(cards), "A straight was detected, though it shouldn't have been.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects with almost a straight, it's correctly ignored.
        /// </summary>
        [TestMethod]
        public void FourStraightIgnored()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Four),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Six),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
            };

            Assert.IsNull(GameLogic.HandRanking.ContainsStraight(cards), "A straight was detected, though it shouldn't have been.");
        }

        /// <summary>
        /// In a long list of <see cref="Card"/> objects with a long straight, the highest value of the straight is found.
        /// </summary>
        [TestMethod]
        public void HighestValueInLongStraight()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Four),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Six),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
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
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Two),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Four),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
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
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Two),
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
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Queen),
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
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Eight),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Queen),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Queen),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNotNull(topValue, "An ace-high straight was not determined succesfully.");
        }

        /// <summary>
        /// In a list of <see cref="Card"/> objects that represents Quads with the rest of the cards the same, it won't break.
        /// </summary>
        [TestMethod]
        public void TolerantOfQuadsFull()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsStraight(cards);
            Assert.IsNull(topValue, "Failed to ignore quads full correctly.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with 4 of the same suit, a flush is determined correctly.
        /// </summary>
        [TestMethod]
        public void IgnoresFourFlush()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.IsNull(topValue, "Failed to not classify a 4 flush as a flush.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with no flush, it's correctly ignored.
        /// </summary>
        [TestMethod]
        public void IgnoresNoFlush()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Diamond, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.IsNull(topValue, "Failed to not classify collection with no more than 2 of the same suit as a flush.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with 5 of the same suit, a flush is determined correctly.
        /// </summary>
        [TestMethod]
        public void DetectsCorrectFlush()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.IsNotNull(topValue, "Failed to correctly classify a flush.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with 5 of the same suit, the high card of the flush is determined correctly.
        /// </summary>
        [TestMethod]
        public void GetsCorrectHighCard()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.AreEqual(GameValues.Value.Ten, topValue, "Failed to correctly determine the high card in a flush.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with an ace high flush, the high card is determined correctly.
        /// </summary>
        [TestMethod]
        public void GetsCorrectAceHighCard()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ace),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.AreEqual(GameValues.Value.Ace, topValue, "Failed to correctly determine an ace high flush.");            
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with 6 of the same suit, a flush is determined correctly.
        /// </summary>
        [TestMethod]
        public void SixFlush()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Heart, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.AreEqual(GameValues.Value.Jack, topValue, "Failed to correctly determine the high card in a 6 card flush.");
        }

        /// <summary>
        /// Given a list of <see cref="Card"/> objects with 7 of the same suit, a flush is determined correctly.
        /// </summary>
        [TestMethod]
        public void SevenFlush()
        {
            List<HoldemBattle.Models.Card> cards = new List<HoldemBattle.Models.Card>()
            {
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Ten),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Three),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Five),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Seven),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Nine),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.Jack),
                new HoldemBattle.Models.Card(GameValues.Suit.Club, GameValues.Value.King),
            };

            GameValues.Value? topValue = GameLogic.HandRanking.ContainsFlush(cards);
            Assert.AreEqual(GameValues.Value.King, topValue, "Failed to correctly determine the high card in a 7 card flush.");
        }
    }
}
