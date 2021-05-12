// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            string[] players = new string[]{ "Peter","Ekaterina","Alexander" };
            MonopolyPlayer[] expectedPlayers = new MonopolyPlayer[]
            {
                new MonopolyPlayer("Peter"),
                new MonopolyPlayer("Ekaterina"),
                new MonopolyPlayer("Alexander")
            };
            Monopoly monopoly = new Monopoly(players,3);
            MonopolyPlayer[] actualPlayers = monopoly.GetPlayersList().ToArray();

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }
        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            AMonopolyField[] expectedCompanies = {
                new AutoMonopolyField( "Ford" ),
                new FoodMonopolyField( "MCDonald" ),
                new ClotherMonopolyField( "Lamoda" ),
                new TravelMonopolyField( "Air Baltic" ),
                new TravelMonopolyField( "Nordavia" ),
                new PrisonMonopolyField( "Bastilia" ),
                new FoodMonopolyField( "MCDonald" ),
                new AutoMonopolyField( "Tesla" )
            };

            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            AMonopolyField[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);

            AMonopolyField x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            MonopolyPlayer actualPlayer = monopoly.GetPlayerInfo(1);
            MonopolyPlayer expectedPlayer = new MonopolyPlayer("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            AMonopolyField actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual( actualPlayer, actualField.Owner );
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            AMonopolyField x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            x = monopoly.GetFieldByName("Ford");
            monopoly.Renta(2, x);
            MonopolyPlayer player1 = monopoly.GetPlayerInfo(1);
            Assert.AreEqual(5750, player1.Amount);
            MonopolyPlayer player2 = monopoly.GetPlayerInfo(2);
            Assert.AreEqual(5750, player2.Amount);
        }
    }
}
