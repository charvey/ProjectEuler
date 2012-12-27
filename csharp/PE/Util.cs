using System;

public static class Util
{
    public static ulong gcd(ulong a, ulong b)
    {
        return gcd_r(a > b ? a : b, a < b ? a : b);
    }

    private static ulong gcd_r(ulong a, ulong b)
    {
        return b == 0 ? a : gcd_r(b, a % b);
    }
}
