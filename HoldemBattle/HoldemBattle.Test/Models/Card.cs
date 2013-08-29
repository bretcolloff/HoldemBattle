//-----------------------------------------------------------------------
// <copyright file="Card.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents the model of a physical playing card.</summary>
//-----------------------------------------------------------------------

namespace HoldemBattle.Test
{
    using HoldemBattle.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Contains tests around the <see cref="Card"/> class.
    /// </summary>
    [TestClass]
    public class Card
    {
        /// <summary>
        /// The Value property on the <see cref="Card"/> class correctly returns the value set in the constructor.
        /// </summary>
        [TestMethod]
        public void ConstructorSetsValue()
        {
            var card = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Ace);
            Assert.AreEqual(GameValues.Value.Ace, card.Value, "Value set in constructor didn't match the property value.");
        }

        /// <summary>
        /// The Suit property on the <see cref="Card"/> class correctly returns the value set in the constructor.
        /// </summary>
        [TestMethod]
        public void ConstructorSetsSuit()
        {
            var card = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Ace);
            Assert.AreEqual(GameValues.Suit.Spade, card.Suit, "Suit set in constructor didn't match the property value.");
        }

        /// <summary>
        /// The greater than operator for the <see cref="Card"/> class works correctly in the true case.
        /// </summary>
        [TestMethod]
        public void GreaterThan()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Ace);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsTrue(left > right, "Ace should be greater than 2.");
        }

        /// <summary>
        /// The greater than operator for the <see cref="Card"/> class works correctly in the false case.
        /// </summary>
        [TestMethod]
        public void GreaterThanFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Ace);

            Assert.IsFalse(left > right, "Ace should be greater than 2.");
        }

        /// <summary>
        /// The less than operator for the <see cref="Card"/> class works correctly in the true case.
        /// </summary>
        [TestMethod]
        public void LessThan()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);

            Assert.IsTrue(left < right, "2 should be less than 3.");
        }

        /// <summary>
        /// The less than operator for the <see cref="Card"/> class works correctly in the false case.
        /// </summary>
        [TestMethod]
        public void LessThanFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsFalse(left < right, "2 should be less than 3.");
        }

        /// <summary>
        /// The inequality operator for the <see cref="Card"/> class works correctly in the true case.
        /// </summary>
        [TestMethod]
        public void NotEqualTo()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsTrue(left != right, "2 should not be equal to 3.");
        }

        /// <summary>
        /// The inequality operator for the <see cref="Card"/> class works correctly in the false case.
        /// </summary>
        [TestMethod]
        public void NotEqualToFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);

            Assert.IsFalse(left != right, "3 should be equal to 3.");
        }

        /// <summary>
        /// The equality operator for the <see cref="Card"/> class works correctly in the true case.
        /// </summary>
        [TestMethod]
        public void EqualityTest()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);

            Assert.IsTrue(left == right, "3 should be equal to 3.");
        }

        /// <summary>
        /// The equality operator for the <see cref="Card"/> class works correctly in the false case.
        /// </summary>
        [TestMethod]
        public void EqualityTestFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsFalse(left == right, "3 should not be equal to 2.");
        }

        /// <summary>
        /// The value equality method for the <see cref="Card"/> class works correctly in the true case.
        /// </summary>
        [TestMethod]
        public void MemberEquals()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);

            Assert.IsTrue(left.Equals(right), "3 should be equal to 3.");
        }

        /// <summary>
        /// The value equality method for the <see cref="Card"/> class works correctly in the false case.
        /// </summary>
        [TestMethod]
        public void MemberEqualsFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsFalse(left.Equals(right), "3 should not be equal to 2.");
        }

        /// <summary>
        /// The reference equality method for the <see cref="Card"/> class works correctly for pure reference equality.
        /// </summary>
        [TestMethod]
        public void ReferenceEqual()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = (object)left;

            Assert.IsTrue(left.Equals(right), "An object and reference to the same object should pass reference equality.");
        }

        /// <summary>
        /// The reference equality method for the <see cref="Card"/> class works correctly for value equality and not reference equality.
        /// </summary>
        [TestMethod]
        public void ReferenceEqualValues()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = (object)new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);

            Assert.IsTrue(left.Equals(right), "The objects with different references should pass equality as they have the same values.");
        }

        /// <summary>
        /// The reference equality method for the <see cref="Card"/> class works correctly with no reference or value equality.
        /// </summary>
        [TestMethod]
        public void ReferenceEqualFail()
        {
            var left = new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Three);
            var right = (object)new HoldemBattle.Models.Card(GameValues.Suit.Spade, GameValues.Value.Two);

            Assert.IsFalse(left.Equals(right), "Both objects have different values, so equality should fail.");
        }
    }
}
