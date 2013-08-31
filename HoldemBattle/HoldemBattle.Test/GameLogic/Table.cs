//-----------------------------------------------------------------------
// <copyright file="Table.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents the model of a physical playing card.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests for the <see cref="Table"/> class.
    /// </summary>
    [TestClass]
    public sealed class Table
    {
        /// <summary>
        /// Constructor cannot take a null <see cref="StakeInfo"/>.
        /// </summary>
        [TestMethod]
        public void ConstructorNoNullStake()
        {
            try
            {
                new GameLogic.Table(2, null);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Constructor should not accept a null StakeInfo.");
        }

        /// <summary>
        /// Constructor cannot instantiate with a 1 player capacity.
        /// </summary>
        [TestMethod]
        public void ConstructorNoOneMaxPlayers()
        {
            try
            {
                new GameLogic.Table(1, new GameLogic.StakeInfo(1, 2));
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("Constructor should not instantiate with a player capacity of 1.");
        }

        /// <summary>
        /// Constructor cannot instantiate with a 0 player capacity.
        /// </summary>
        [TestMethod]
        public void ConstructorNoZeroMaxPlayers()
        {
            try
            {
                new GameLogic.Table(0, new GameLogic.StakeInfo(1, 2));
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("Constructor should not instantiate with a player capacity of 0.");
        }

        /// <summary>
        /// Constructor can instantiate with a 2 player capacity.
        /// </summary>
        [TestMethod]
        public void ConstructorTwoPlayers()
        {
            new GameLogic.Table(2, new GameLogic.StakeInfo(1, 2));
        }

        /// <summary>
        /// Constructor can instantiate with a 10 player capacity.
        /// </summary>
        [TestMethod]
        public void ConstructorTenPlayers()
        {
            new GameLogic.Table(10, new GameLogic.StakeInfo(1, 2));
        }

        /// <summary>
        /// Constructor cannot instantiate with an 11 player capacity.
        /// </summary>
        [TestMethod]
        public void ConstructorNoElevenPlayers()
        {
            try
            {
                new GameLogic.Table(11, new GameLogic.StakeInfo(1, 2));
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("Constructor should not instantiate with a player capacity of 11.");
        }

        /// <summary>
        /// The <see cref="Table"/> generates a GUID Id.
        /// </summary>
        [TestMethod]
        public void IdPropertyIsGUID()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            Assert.IsNotNull(table.Id, "The Table should generate an identifying GUID.");
        }

        /// <summary>
        /// The RemainingSeats property returns a correct value with no players.
        /// </summary>
        [TestMethod]
        public void TableCapacityCorrectWhenEmpty()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            Assert.AreEqual(6, table.RemainingSeats, "The number of remaining seats is incorrect.");
        }

        /// <summary>
        /// The RemainingSeats property returns correctly when the table is full.
        /// </summary>
        [TestMethod]
        public void TableCapacityWhenFull()
        {
            uint playerCapacity = 6;
            var table = new GameLogic.Table(playerCapacity, new GameLogic.StakeInfo(1, 2));

            for (int i = 0; i < playerCapacity; i++)
            {
                var player = new Models.Player(i.ToString(), "key", 0);
                table.AddPlayer(player);
            }

            Assert.AreEqual(0, table.RemainingSeats, "There should be no seats remaining at the table.");
        }

        /// <summary>
        /// The RemainingSeats property returns correctly when there are players at the table.
        /// </summary>
        [TestMethod]
        public void TableCapacityWithPlayers()
        {
            uint playerCapacity = 6;
            var table = new GameLogic.Table(playerCapacity, new GameLogic.StakeInfo(1, 2));

            for (int i = 0; i < playerCapacity - 1; i++)
            {
                var player = new Models.Player(i.ToString(), "key", 0);
                table.AddPlayer(player);
            }

            Assert.AreEqual(1, table.RemainingSeats, "There should be a seat remaining at the table.");
        }

        /// <summary>
        /// The <see cref="StakeInfo"/> returned matches the one provided.
        /// </summary>
        [TestMethod]
        public void StakeInfoCorrect()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            Assert.AreEqual(1, table.StakeInfo.SmallBlind, "Unexpected small blind value.");
            Assert.AreEqual(2, table.StakeInfo.BigBlind, "Unexpected big blind value.");
        }

        /// <summary>
        /// A player can be added successfully when the table is below capacity.
        /// </summary>
        [TestMethod]
        public void AddPlayerWhenBelowCapacity()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            table.AddPlayer(new Models.Player("name", "key", 1000));
        }

        /// <summary>
        /// Adding a player to the table removes stake money from them.
        /// </summary>
        [TestMethod]
        public void AddingPlayerTakesStakeMoney()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var player = new Models.Player("name", "key", 1000);
            table.AddPlayer(player);

            Assert.AreEqual(player.Cash, 800, "Unexpected amount of cash assigned to player.");
        }

        /// <summary>
        /// A player cannot be added when the table is at capacity.
        /// </summary>
        [TestMethod]
        public void CannotAddPlayerAtCapacity()
        {
            uint tableCapacity = 6;
            var table = new GameLogic.Table(tableCapacity, new GameLogic.StakeInfo(1, 2));

            for (int i = 0; i < tableCapacity; i++)
            {
                table.AddPlayer(new Models.Player(i.ToString(), "key", 0));
            }

            try
            {
                table.AddPlayer(new Models.Player("name", "key", 0));
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("A table shouldn't accept new players when at capacity.");
        }

        /// <summary>
        /// If a player cannot be added to the table, no stake money is taken.
        /// </summary>
        [TestMethod]
        public void FailureToAddAPlayerDoesNotTakeStake()
        {
            uint tableCapacity = 6;
            var table = new GameLogic.Table(tableCapacity, new GameLogic.StakeInfo(1, 2));

            for (int i = 0; i < tableCapacity; i++)
            {
                table.AddPlayer(new Models.Player(i.ToString(), "key", 0));
            }

            var extraPlayer = new Models.Player("name", "key", 1000);

            try
            {
                table.AddPlayer(extraPlayer);
            }
            catch (InvalidOperationException)
            {
                Assert.AreEqual(1000, extraPlayer.Cash, "Player had an unexpected amount of cash assigned.");
            }
        }

        /// <summary>
        /// A player that is already seated cannot be added to a table again.
        /// </summary>
        [TestMethod]
        public void CannotAddDuplicatePlayer()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var player = new Models.Player("name", "key", 1000);

            table.AddPlayer(player);

            try
            {
                table.AddPlayer(player);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("An already seated player cannot be added to the table again.");
        }

        /// <summary>
        /// When the table is below capacity, a player can be removed successfully.
        /// </summary>
        [TestMethod]
        public void CanRemovePlayerBelowCapacity()
        {
            var table = new GameLogic.Table(10, new GameLogic.StakeInfo(1, 2));
            var seatedPlayer = new Models.Player("seated", "key", 1000);

            for (int i = 0; i < 5; i++)
            {
                table.AddPlayer(new Models.Player(i.ToString(), "key", 1000));
            }

            table.RemovePlayer(seatedPlayer);
        }

        /// <summary>
        /// When the table is at capacity, a player can be removed successfully.
        /// </summary>
        [TestMethod]
        public void CanRemovePlayerAtCapacity()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var seatedPlayer = new Models.Player("seated", "key", 1000);

            for (int i = 0; i < 5; i++)
            {
                table.AddPlayer(new Models.Player(i.ToString(), "key", 1000));
            }

            table.RemovePlayer(seatedPlayer);
        }

        /// <summary>
        /// Removing a seated player returns their money to them.
        /// </summary>
        [TestMethod]
        public void RemovingPlayerReturnsMoney()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var seatedPlayer = new Models.Player("seated", "key", 1000);

            table.AddPlayer(seatedPlayer);
            Assert.AreEqual(800, seatedPlayer.Cash, "Unexpected cash value on player after seating.");

            table.RemovePlayer(seatedPlayer);
            Assert.AreEqual(1000, seatedPlayer.Cash, "Upon leaving the table, the players cash value is incorrect.");
        }

        /// <summary>
        /// Attempting to remove a non-seated player does not throw.
        /// </summary>
        [TestMethod]
        public void RemovingNonSeatedPlayerDoesNotThrow()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var seatedPlayer = new Models.Player("seated", "key", 1000);

            table.AddPlayer(seatedPlayer);

            var player = new Models.Player("name", "key", 1000);

            table.RemovePlayer(player);
        }

        /// <summary>
        /// Attempting to remove a non-seated player from a table doesn't affect their cash value.
        /// </summary>
        [TestMethod]
        public void RemovingNonSeatedPlayerDoesntReturnMoney()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var seatedPlayer = new Models.Player("seated", "key", 1000);

            table.AddPlayer(seatedPlayer);

            var player = new Models.Player("name", "key", 1000);

            table.RemovePlayer(player);

            Assert.AreEqual(1000, player.Cash, "The un-seated players cash value changed.");
        }

        /// <summary>
        /// Attempting to remove a player from the table when no players are seated does not throw.
        /// </summary>
        [TestMethod]
        public void RemovingPlayerNoPlayersDoesNotThrow()
        {
            var table = new GameLogic.Table(6, new GameLogic.StakeInfo(1, 2));
            var player = new Models.Player("name", "key", 1000);

            table.RemovePlayer(player);
        }
    }
}
