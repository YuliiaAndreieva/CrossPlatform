using System.Numerics;
using App;
using Xunit.Abstractions;

namespace Tests;

public class BinarySequenceServiceTests(ITestOutputHelper output)
{
    [Theory]
    [InlineData(1, 7)]    
    [InlineData(2, 11)]   
    [InlineData(3, 13)]   
    [InlineData(4, 14)]   
    [InlineData(5, 19)]   
    [InlineData(6, 21)]   
    [InlineData(7, 22)]   
    [InlineData(8, 25)]
    [InlineData(10, 28)]
    public void FindNthNumberWithThreeOnes_ReturnsCorrectValue(int n, int expected)
    {
        // Act
        output.WriteLine($"Finding {n}-th number with three '1's in binary...");
        var result = BinarySequenceService.FindNthNumberWithThreeOnes(n);
        output.WriteLine($"Expected: {expected}, Actual: {result}");

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(5, 3, 10)]
    [InlineData(4, 2, 6)]
    [InlineData(6, 3, 20)]
    [InlineData(10, 0, 1)]
    [InlineData(10, 10, 1)]
    public void BinomialCoefficient_ValidInputs_ReturnsExpected(long n, int k, long expected)
    {
        // Act
        long result = BinarySequenceService.BinomialCoefficient(n, k);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(5, -1)]
    [InlineData(5, 6)]
    [InlineData(3, 4)]
    public void BinomialCoefficient_InvalidInputs_ReturnsZero(long n, int k)
    {
        // Act
        long result = BinarySequenceService.BinomialCoefficient(n, k);

        // Assert
        Assert.Equal(0, result);
    }
    
    [Theory]
    [InlineData(1, 2)]   // C(3,3)=1 >=1
    [InlineData(4, 3)]   // C(4,3)=4 >=4
    [InlineData(6, 4)]   // C(5,3)=10 >=6
    [InlineData(10, 4)]  // C(5,3)=10 >=10
    [InlineData(11, 5)]  // C(6,3)=20 >=11
    public void FindR_ValidInputs_ReturnsExpected(long n, long expectedR)
    {
        // Act
        long r = BinarySequenceService.FindR(n);

        // Assert
        Assert.Equal(expectedR, r);
    }
    
    [Theory]
    [InlineData(4, 1, 0, 1)] // r=4, nPrime=1 → p=0, q=1 → number=19
    [InlineData(4, 2, 0, 2)] // r=4, nPrime=2 → p=0, q=2 → number=21
    [InlineData(4, 3, 1, 2)] // r=4, nPrime=3 → p=1, q=2 → number=22
    [InlineData(4, 4, 0, 3)] // r=4, nPrime=4 → p=0, q=3 → number=25
    [InlineData(4, 5, 1, 3)] // r=4, nPrime=5 → p=1, q=3 → number=26
    [InlineData(4, 6, 2, 3)] // r=4, nPrime=6 → p=2, q=3 → number=28
    public void FindPQ_ValidInputs_ReturnsExpected(long r, long nPrime, long expectedP, long expectedQ)
    {
        // Act
        (long p, long q) = BinarySequenceService.FindPQ(r, nPrime);

        // Assert
        Assert.Equal(expectedP, p);
        Assert.Equal(expectedQ, q);
    }
    
    [Theory]
    [InlineData(4, 0)]
    [InlineData(5, -1)]
    public void FindPQ_InvalidInputs_ThrowsArgumentException(long r, long nPrime)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => BinarySequenceService.FindPQ(r, nPrime));
    }
    
    [Theory]
    [InlineData(0, 1, 2, 7)]    // 2^0 + 2^1 + 2^2 = 1 + 2 + 4 = 7
    [InlineData(0, 1, 3, 11)]   // 2^0 + 2^1 + 2^3 = 1 + 2 + 8 = 11
    [InlineData(0, 2, 3, 13)]   // 2^0 + 2^2 + 2^3 = 1 + 4 + 8 = 13
    [InlineData(1, 2, 3, 14)]   // 2^1 + 2^2 + 2^3 = 2 + 4 + 8 = 14
    [InlineData(0, 1, 4, 19)]   // 2^0 + 2^1 + 2^4 = 1 + 2 + 16 = 19
    public void ComputeNumber_ValidInputs_ReturnsExpected(long p, long q, long r, long expected)
    {
        // Act
        BigInteger number = BinarySequenceService.ComputeNumber(p, q, r);

        // Assert
        Assert.Equal(expected, (long)number);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void FindNthNumberWithThreeOnes_InvalidN_ThrowsArgumentException(long n)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => BinarySequenceService.FindNthNumberWithThreeOnes(n));
    }
}