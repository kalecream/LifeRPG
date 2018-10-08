using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeRPG.Utils
{
    public static class Utilities
    {
        public static DateTime ToDateTime(long? input)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(input ?? 0).ToLocalTime();
        }
    }
}
