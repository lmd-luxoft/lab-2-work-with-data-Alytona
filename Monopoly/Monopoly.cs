using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class MonopolyField
    {
        public string Name
        {
            get; set;
        }

        public Monopoly.Type Type
        {
            get; set;
        }

        public int IntValue
        {
            get; set;
        }

        public bool BoolValue
        {
            get; set;
        }
    }

    class AutoMonopolyField : MonopolyField
    {
    }

    class MonopolyPlayer
    {
        public const int START_AMOUNT = 6000;

        public readonly string Name;

        public int Amount
        {
            get; private set;
        }
        public MonopolyPlayer (string name)
        {
            Name = name;
            Amount = START_AMOUNT;
        }
        public MonopolyPlayer (string name, int startAmount)
        {
            Name = name;
            Amount = startAmount;
        }

        public int minusAmount (int minusValue)
        {
            Amount -= minusValue;
            return Amount;
        }
        public int plusAmount (int plusValue)
        {
            Amount += plusValue;
            return Amount;
        }

        public bool Equals (MonopolyPlayer otherPlayer)
        {
            return otherPlayer.Name == Name && otherPlayer.Amount == Amount;
        }
    }

    class Monopoly
    {
        private List<MonopolyPlayer> _players = new List<MonopolyPlayer>();

        private List<Tuple<string, Monopoly.Type, int, bool>> _fields = new List<Tuple<string, Type, int, bool>>();

        public Monopoly(string[] playerNames, int playersQuantity)
        {
            for (int i = 0; i < playersQuantity; i++)
            {
                _players.Add(new MonopolyPlayer( playerNames[i] ) );     
            }
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Ford", Monopoly.Type.AUTO, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Lamoda", Monopoly.Type.CLOTHER, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Air Baltic", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Nordavia", Monopoly.Type.TRAVEL, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("Prison", Monopoly.Type.PRISON, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("MCDonald", Monopoly.Type.FOOD, 0, false));
            _fields.Add(new Tuple<string, Monopoly.Type, int, bool>("TESLA", Monopoly.Type.AUTO, 0, false));
        }

        internal List<MonopolyPlayer> GetPlayersList()
        {
            return _players;
        }

        internal enum Type
        {
            AUTO,
            FOOD,
            CLOTHER,
            TRAVEL,
            PRISON,
            BANK
        }

        internal List<Tuple<string, Monopoly.Type, int, bool>> GetFieldsList()
        {
            return _fields;
        }

        internal Tuple<string, Type, int, bool> GetFieldByName(string v)
        {
            return (from p in _fields where p.Item1 == v select p).FirstOrDefault();
        }

        internal bool Buy(int v, Tuple<string, Type, int, bool> k)
        {
            var x = GetPlayerInfo(v);
            switch(k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 != 0)
                        return false;
                    _players[v - 1].minusAmount( 500 );
                    break;
                case Type.FOOD:
                    if (k.Item3 != 0)
                        return false;
                    _players[v - 1].minusAmount( 250 );
                    break;
                case Type.TRAVEL:
                    if (k.Item3 != 0)
                        return false;
                    _players[v - 1].minusAmount( 700 );
                    break;
                case Type.CLOTHER:
                    if (k.Item3 != 0)
                        return false;
                    _players[v - 1].minusAmount( 100 );
                    break;
                default:
                    return false;
            }
            int i = _players.Select((item, index) => new { name = item.Name, index = index })
                .Where(n => n.name == x.Name)
                .Select(p => p.index).FirstOrDefault();
            _fields[i] = new Tuple<string, Type, int, bool>(k.Item1, k.Item2, v, k.Item4);
             return true;
        }

        internal MonopolyPlayer GetPlayerInfo (int v)
        {
            return _players[v - 1];
        }

        internal bool Renta(int v, Tuple<string, Type, int, bool> k)
        {
            var z = GetPlayerInfo(v);
            MonopolyPlayer o = null;
            switch(k.Item2)
            {
                case Type.AUTO:
                    if (k.Item3 == 0)
                        return false;
                    o =  GetPlayerInfo(k.Item3);
                    z.minusAmount( 250 );
                    o.plusAmount( 250 );
                    break;
                case Type.FOOD:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z.minusAmount( 250 );
                    o.plusAmount( 250 );

                    break;
                case Type.TRAVEL:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z.minusAmount( 300 );
                    o.plusAmount( 300 );
                    break;
                case Type.CLOTHER:
                    if (k.Item3 == 0)
                        return false;
                    o = GetPlayerInfo(k.Item3);
                    z.minusAmount( 100 );
                    o.plusAmount( 1000 );

                    break;
                case Type.PRISON:
                    z.minusAmount( 1000 );
                    break;
                case Type.BANK:
                    z.minusAmount( 700 );
                    break;
                default:
                    return false;
            }
            _players[v - 1] = z;
            if(o != null)
                _players[k.Item3 - 1] = o;
            return true;
        }
    }
}
