using System;

namespace Blackbox.Utils
{
    public static class BlackboxUtils
    {
        private static Random random = new Random();
        public static Random Random
        {
            get
            {
                return random;
            }
        }
    }
}
