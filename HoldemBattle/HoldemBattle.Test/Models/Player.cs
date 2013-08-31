//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Stores values used for cards.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests for the <see cref="Player"/> class.
    /// </summary>
    [TestClass]
    public sealed class Player
    {
        /// <summary>
        /// The constructor can't take an empty name value.
        /// </summary>
        [TestMethod]
        public void ConstructorEmptyName()
        {
            try
            {
                new HoldemBattle.Models.Player(string.Empty, "key", 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Constructor accepted empty name value.");
        }

        /// <summary>
        /// The constructor can't take a null name value.
        /// </summary>
        [TestMethod]
        public void ConstructorNullName()
        {
            try
            {
                new HoldemBattle.Models.Player(null, "key", 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Constructor accepted null name value.");
        }

        /// <summary>
        /// Constructor cannot take an empty key value.
        /// </summary>
        [TestMethod]
        public void ConstructorEmptyKey()
        {
            try
            {
                new HoldemBattle.Models.Player("name", string.Empty, 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Constructor accepted empty key value.");
        }

        /// <summary>
        /// Constructor cannot take a null key value.
        /// </summary>
        [TestMethod]
        public void ConstructorNullKey()
        {
            try
            {
                new HoldemBattle.Models.Player("name", null, 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail("Constructor accepted null key value.");
        }

        /// <summary>
        /// Constructor can accept zero cash.
        /// </summary>
        [TestMethod]
        public void ConstructorZeroCash()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 0);
            Assert.AreEqual(0, player.Cash, "Expected player object to contain 0 cash.");
        }

        /// <summary>
        /// Constructor can accept negative cash.
        /// </summary>
        [TestMethod]
        public void ConstructorNegativeCash()
        {
            var player = new HoldemBattle.Models.Player("name", "key", -1);
            Assert.AreEqual(-1, player.Cash, "Expected player object to contain < 0 cash.");
        }

        /// <summary>
        /// Constructor can accept positive cash.
        /// </summary>
        [TestMethod]
        public void ConstructorPositiveCash()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 1);
            Assert.AreEqual(1, player.Cash, "Expected player object to contain > 0 cash.");
        }

        /// <summary>
        /// Player object can add money.
        /// </summary>
        [TestMethod]
        public void AddPositiveMoney()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 0);
            Assert.AreEqual(0, player.Cash, "Expected player object to contain 0 cash.");

            player.AddCash(1);
            Assert.AreEqual(1, player.Cash, "Expected the player cash to have increased.");
        }

        /// <summary>
        /// Player object can safely add 0 money.
        /// </summary>
        [TestMethod]
        public void AddZeroMoney()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 0);
            Assert.AreEqual(0, player.Cash, "Expected player object to contain 0 cash.");

            player.AddCash(0);
            Assert.AreEqual(0, player.Cash, "Expected the player cash to have not increased.");
        }

        /// <summary>
        /// Player object can remove money.
        /// </summary>
        [TestMethod]
        public void RemovePositiveMoney()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 1);
            Assert.AreEqual(1, player.Cash, "Expected player object to contain 1 cash.");

            player.RemoveCash(1);
            Assert.AreEqual(0, player.Cash, "Expected the player cash to have decreased.");
        }

        /// <summary>
        /// Player object can safely remove 0 money.
        /// </summary>
        [TestMethod]
        public void RemoveZeroMoney()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 0);
            Assert.AreEqual(0, player.Cash, "Expected player object to contain 0 cash.");

            player.RemoveCash(0);
            Assert.AreEqual(0, player.Cash, "Expected the player cash to have not decreased.");
        }

        /// <summary>
        /// Validate the Name property returns the correct value.
        /// </summary>
        [TestMethod]
        public void NameProperty()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 0);
            Assert.AreEqual("name", player.Name, "Unexpected result from the Name property.");
        }

        /// <summary>
        /// Validate the Cash property returns the correct value.
        /// </summary>
        [TestMethod]
        public void CashProperty()
        {
            var player = new HoldemBattle.Models.Player("name", "key", 10);
            Assert.AreEqual(10, player.Cash, "Unexpected result from the Cash property.");
        }
    }
}
