//-----------------------------------------------------------------------
// <copyright file="StakeInfo.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents the model of a physical playing card.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests for the StakeInfo class.
    /// </summary>
    [TestClass]
    public sealed class StakeInfo
    {
        /// <summary>
        /// The small blind can't be bigger than the big blind.
        /// </summary>
        [TestMethod]
        public void SmallBlindCannotBeBiggerThanBigBlind()
        {
            try
            {
                new HoldemBattle.GameLogic.StakeInfo(1, 0);
            }
            catch (InvalidOperationException)
            {
                return;
            }

            Assert.Fail("The small blind was larger than the big blind.");
        }

        /// <summary>
        /// The small blind can be equal to big blind.
        /// </summary>
        [TestMethod]
        public void SmallBlindCanEqualBigBlind()
        {
            new HoldemBattle.GameLogic.StakeInfo(0, 0);
        }

        /// <summary>
        /// The small blind can be smaller than the big blind.
        /// </summary>
        [TestMethod]
        public void SmallBlindSmallerThanBigBlind()
        {
            new HoldemBattle.GameLogic.StakeInfo(0, 1);
        }

        /// <summary>
        /// The SmallBlind property returns the correct value.
        /// </summary>
        [TestMethod]
        public void SmallBlindProperty()
        {
            var stakeInfo = new HoldemBattle.GameLogic.StakeInfo(5, 10);
            Assert.AreEqual(5, stakeInfo.SmallBlind, "Unexpected return value from SmallBlind.");
        }

        /// <summary>
        /// The BigBlind property returns the correct value.
        /// </summary>
        [TestMethod]
        public void BigBlindProperty()
        {
            var stakeInfo = new HoldemBattle.GameLogic.StakeInfo(5, 10);
            Assert.AreEqual(10, stakeInfo.BigBlind, "Unexpected return value from BigBlind.");
        }
    }
}
