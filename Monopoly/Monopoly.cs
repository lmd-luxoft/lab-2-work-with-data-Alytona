using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Monopoly
    {
        private readonly List<MonopolyPlayer> _players = new List<MonopolyPlayer>();

        private readonly List<AMonopolyField> _fields = new List<AMonopolyField>();

        public Monopoly(string[] playerNames, int playersQuantity)
        {
            for (int i = 0; i < playersQuantity; i++)
            {
                _players.Add(new MonopolyPlayer( playerNames[i] ) );     
            }

            _fields.Add( new AutoMonopolyField( "Ford" ) );
            _fields.Add( new FoodMonopolyField( "MCDonald" ) );
            _fields.Add( new ClotherMonopolyField( "Lamoda" ) );
            _fields.Add( new TravelMonopolyField( "Air Baltic" ) );
            _fields.Add( new TravelMonopolyField( "Nordavia" ) );
            _fields.Add( new PrisonMonopolyField( "Bastilia" ) );
            _fields.Add( new FoodMonopolyField( "MCDonald" ) );
            _fields.Add( new AutoMonopolyField( "Tesla" ) );
        }

        internal List<MonopolyPlayer> GetPlayersList()
        {
            return _players;
        }

        internal List<AMonopolyField> GetFieldsList()
        {
            return _fields;
        }

        internal AMonopolyField GetFieldByName (string v)
        {
            return (from p in _fields where p.Name == v select p).FirstOrDefault();
        }

        internal bool Buy(int buyerPlayerIndex, AMonopolyField monopolyField)
        {
            var buyerPlayer = GetPlayerInfo(buyerPlayerIndex);

            if (!monopolyField.SellTo( buyerPlayer ))
                return false;

             return true;
        }

        internal MonopolyPlayer GetPlayerInfo (int playerIndex)
        {
            return _players[playerIndex - 1];
        }

        internal bool Renta(int tenantPlayerIndex, AMonopolyField monopolyField)
        {
            var tenantPlayer = GetPlayerInfo( tenantPlayerIndex );
            return monopolyField.RentFrom( tenantPlayer );
        }
    }
}
