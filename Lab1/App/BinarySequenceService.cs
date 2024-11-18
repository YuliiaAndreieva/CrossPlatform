using System.Numerics;

namespace App;

public static class BinarySequenceService
{
    public static BigInteger FindNthNumberWithThreeOnes(long n)
    {
        if (n <= 0)
            throw new ArgumentException("N must be a positive integer.");
        
        long r = FindR(n);
        
        long cR3 = BinomialCoefficient(r, 3);
        long nPrime = n - cR3;

        if(nPrime <= 0)
            throw new ArgumentException("N is too small.");
        
        (long p, long q) = FindPQ(r, nPrime);
        
        BigInteger number = ComputeNumber(p, q, r);
        return number;
    }
    
    public static long FindR(long n)
    {
        long left = 2;
        long right = 1000000;
        long r = 0;

        while(left <= right)
        {
            long mid = left + (right - left) / 2;
            long combinations = BinomialCoefficient(mid + 1, 3);
            if(combinations >= n)
            {
                r = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return r;
    }
    
    public static long BinomialCoefficient(long n, int k)
    {
        if (k < 0 || k > n)
            return 0; 
        if (k == 0 || k == n)
            return 1; 
        
        k = Math.Min(k, (int)n - k);

        long result = 1;
        
        for (int i = 0; i < k; i++)
            result = result * (n - i) / (i + 1);

        return result;
    }
    
    public static (long p, long q) FindPQ(long r, long nPrime)
    {
        for(long q = 1; q < r; q++)
        {
            for(long p = 0; p < q; p++)
            {
                nPrime--;

                if(nPrime is 0)
                {
                    return (p, q);
                }
            }
        }

        throw new ArgumentException("N is too large.");
    }
    
    public static BigInteger ComputeNumber(long p, long q, long r)
    {
        return (BigInteger.One << (int)p) | (BigInteger.One << (int)q) | (BigInteger.One << (int)r);
    }
}