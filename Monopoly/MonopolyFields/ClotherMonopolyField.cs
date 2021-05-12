using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ClotherMonopolyField : AMonopolyField
    {
        public ClotherMonopolyField (string name) : base( name )
        {
        }
        protected override int GetBuyAmount ()
        {
            return 100;
        }
        protected override int GetRentAmount ()
        {
            return 100;
        }
    }
}
