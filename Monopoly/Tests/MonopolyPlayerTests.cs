using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    class MonopolyPlayerTests
    {
        [Test]
        public void CreatePlayerWithDefaultAmountCorrectName ()
        {
            MonopolyPlayer player = new MonopolyPlayer( "Peter" );
            Assert.AreEqual( "Peter", player.Name );
        }
        [Test]
        public void CreatePlayerWithDefaultAmountCorrectAmount ()
        {
            MonopolyPlayer player = new MonopolyPlayer( "Peter" );
            Assert.AreEqual( MonopolyPlayer.START_AMOUNT, player.Amount );
        }
    }
}
