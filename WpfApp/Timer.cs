using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Test
    {
    public class Timer
        {
        double ticksPerSecond = 0.0;

        public Timer()
            {
            DateTime dt = DateTime.Now;
            DateTime dtPlusOneSecond = dt.AddSeconds(1);
            this.ticksPerSecond = dtPlusOneSecond.Ticks - dt.Ticks;
            }

        private double TicksToSeconds(long ticks)
            {
            return ticks / this.ticksPerSecond;
            }

        public double Run(Action action)
            {
            DateTime before = DateTime.Now;
            action();
            DateTime after = DateTime.Now;
            return TicksToSeconds(after.Ticks - before.Ticks);
            }
        }
    }
