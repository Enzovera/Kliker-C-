using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliker
{
    class player : Iplayer
    {
        public player() { }

        double cliks;
        public void setCliks( double d){
            cliks = d;
        }
        public double Cliks 
        {
            get 
            { 
                return Math.Round(cliks, 1); 
            } 
        }
        double clikspersecound;
        public double Clikspersecound 
        { 
            get 
            { 
                return Math.Round(clikspersecound + ((clikspersecound*upgradeslist.upgradadditionalcps)/100), 1); 
            } 
        }
        public void pay(double value)
        {
            cliks = cliks - value;
        }
        public void addcps(double increase)
        {
            clikspersecound = clikspersecound + increase;
        }
        public void addcliks(double a)
        {
            cliks = cliks + a;
        }
    }
}
