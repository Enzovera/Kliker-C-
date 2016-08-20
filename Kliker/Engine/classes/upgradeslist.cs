using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliker
{
    class upgradeslist
    {
        public static List<upgrade> Upgradelist = new List<upgrade>()
        {
            new upgrade(500, 10, 0, "u1_1"),
            new upgrade(5000, 15, 0, "u1_2"),
            new upgrade(50000, 20, 0, "u1_3"),
            new upgrade(500000, 40, 0, "u1_4"),
            new upgrade(1500, 0, 2, "u2_1"),
            new upgrade(15000, 0, 4, "u2_2"),
            new upgrade(150000, 0, 8, "u2_3"),
            new upgrade(1500000, 0, 16, "u2_4")

        };
        public void add(double cost, double additionalcps, double additionalcpc, string label) 
        {
            Upgradelist.Add(new upgrade(cost, additionalcps, additionalcpc, label));
        }
        static public double upgradadditionalcps
        {
            get
            {
                double _u = 0;
                foreach (upgrade u in Upgradelist)
                {
                    _u = _u + u.additionalcps;
                }
                return _u;
            }
        }
        static public double upgradadditionalcpc
        {
            get
            {
                double _u = 1;
                foreach (upgrade u in Upgradelist)
                {
                    double xd = u.additionalcpc;
                    if (u.additionalcpc != 0) 
                    { 
                        _u = _u * u.additionalcpc;  
                    }
                }
                return _u;
            }
        }
    }
}
