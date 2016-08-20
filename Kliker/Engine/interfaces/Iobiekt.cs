using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliker
{
    interface Iobiekt
    {
        void add(player player, int times);
        void setAmount(int a);
        string dprice(int times);
        double Dprice(int times);
    }
}
