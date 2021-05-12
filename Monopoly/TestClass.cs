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
            Tuple<string, Monopoly.Type, int, bool>[] expectedCompanies = 
                new Tuple<string, Monopoly.Type, int, bool>[]{
                new Tuple<string,Monopoly.Type,int,bool>("Ford",Monopoly.Type.AUTO,0,false),
                new Tuple<string,Monopoly.Type,int,bool>("MCDonald", Monopoly.Type.FOOD, 0, false),
                new Tuple<string,Monopoly.Type,int,bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false),
                new Tuple<string, Monopoly.Type, int, bool>("Air Baltic",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Nordavia",Monopoly.Type.TRAVEL,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("Prison",Monopoly.Type.PRISON,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("MCDonald",Monopoly.Type.FOOD,0,false),
                new Tuple<string, Monopoly.Type, int, bool>("TESLA",Monopoly.Type.AUTO,0,false)
            };
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool>[] actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }
        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool> x = monopoly.GetFieldByName("Ford");
            monopoly.Buy(1, x);
            MonopolyPlayer actualPlayer = monopoly.GetPlayerInfo(1);
            MonopolyPlayer expectedPlayer = new MonopolyPlayer("Peter", 5500);
            Assert.AreEqual(expectedPlayer, actualPlayer);
            Tuple<string, Monopoly.Type, int, bool> actualField = monopoly.GetFieldByName("Ford");
            Assert.AreEqual(1, actualField.Item3);
        }
        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            Tuple<string, Monopoly.Type, int, bool>  x = monopoly.GetFieldByName("Ford");
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
