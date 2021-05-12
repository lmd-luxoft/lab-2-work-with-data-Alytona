using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class AutoMonopolyField : AMonopolyField
    {
        public AutoMonopolyField (string name) : base( name )
        {
        }
        protected override int GetBuyAmount ()
        {
            return 500;
        }
        protected override int GetRentAmount ()
        {
            return 250;
        }
    }
}
