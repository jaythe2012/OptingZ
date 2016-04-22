using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OptingZ.Utils
{
    public static class RandomNumberGenerator
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min*10, max*10);
            }
        }
        
    }
}