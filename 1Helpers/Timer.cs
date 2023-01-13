using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class Timer
    {
        double time;

        public void ResetAndStart(double time)
        {
            this.time = time;
        }

        public void Update(double delta)
        {
            time -= delta;
        }

        public bool IsDone()
        {
            return time <= 0;
        }

        public double GetTime() => time; // returns

    }
}
