using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal static class Points
    {
        public static int points = 500;
        public static int amount = 0;
        public static int donations = 0;

        public static int AddPoints(int p)
        {
           return points +=p;
        }

        public static int RemovePoints(int p)
        {
            return points -= p;
        }

        public static int AddAmount(int p)
        {
            return amount += p;
        }

        public static int AddDonation(int d)
        {
            RemovePoints(d);
            return donations += (d*2);
        }
       
    }
}
