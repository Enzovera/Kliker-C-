using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliker
{
    class obiekt : Iobiekt
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        double value;
        double basiccost;
        int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
        }
        double cost 
        { 
            get
            {
                return Math.Round(basiccost * Math.Pow(1.1, amount), 1);
            } 
        }
        public obiekt()
        { }
        public obiekt(int amount, double value, double basiccost, string name) 
        {
            this.basiccost = basiccost;
            this.value = value;
            this.name = name;
        }
        public void add(player player, int times){
            for (int y = 1; y<=times; y++ )
            {
                player.pay(cost);
                player.addcps(value);
                amount++;
            }
        }
        public double Dprice(int times)
        {
            double _suma = cost * ((1 - Math.Pow(1.1, times)) / -0.1);
            return Math.Round(_suma, 1);
        }
        public string dprice(int times)
        {
            double _suma = Dprice(times);
            return String.Format("Koszt: {0} klików", _suma.ToString());
        }
        public void setAmount(player player, int a)
        {
            amount = a;
            player.addcps(value*a);
        }
    }
}
