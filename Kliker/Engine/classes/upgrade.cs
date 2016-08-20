using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliker
{
    class upgrade
    {
        bool active;
        public int IsActive
        {
            get
            {
                if (active == true) return 1;
                else return 0;
            }
        }
        public void setActive()
        {
            active = true;
        }
        double Additionalcps;
        public double additionalcps
        {
            get
            {
                if (active == true)
                    return Additionalcps;
                else
                    return 0;
            }
        }
        double Additionalcpc;
        public double additionalcpc
        {
            get
            {
                if (active == true)
                    return Additionalcpc;
                else
                    return 0;
            }
        }
        double Cost;
        public double cost
        {
            get
            {
                return Cost;
            }
        }
        public upgrade(double cost, double additionalcps, double additionalcpc, string label)
        {
            this.Additionalcps = additionalcps;
            this.Additionalcpc = additionalcpc;
            this.Label = label;
            this.active = false;
            this.Cost = cost;
        }
        string Label;
        public string label
        {
            get
            {
                return label;
            }
        }
    }
}
