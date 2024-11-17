using App;
using Xunit.Abstractions;

namespace Tests;

public class SocksPurchaseServiceTests(ITestOutputHelper output)
{
    [Theory]
    [InlineData(9, new[] { 1, 1, 10, 8, 5, 20 }, 8)]   
    [InlineData(10, new[] { 5, 20, 3, 12, 2, 10 }, 40)] 
    [InlineData(12, new[] { 10, 30, 1, 5, 4, 15 }, 40)]
    [InlineData(15, new[] { 5, 20, 3, 12, 2, 10 }, 60)]
    public void CalculateMinimumCost_ReturnsCorrectCost_WithThreeSuppliers(int n, int[] supplierData, int expectedCost)
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>
        {
            (supplierData[0], supplierData[1]),
            (supplierData[2], supplierData[3]),
            (supplierData[4], supplierData[5])
        };
        
        output.WriteLine($"Test Case: Need {n} pairs of socks");
        foreach (var supplier in suppliers)
        {
            output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
        }

        // Act
        var result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
        
        output.WriteLine($"Calculated cost: {result}, Expected cost: {expectedCost}");

        // Assert
        Assert.Equal(expectedCost, result);
    }
    
    [Theory]
    [InlineData(9, new[] { 1, 1, 10, 8 }, 8)]
    [InlineData(10, new[] { 5, 20, 3, 12 }, 40)]
    [InlineData(8, new[] { 5, 20, 2, 10 }, 40)] 
    [InlineData(12, new[] { 10, 30, 1, 5 }, 40)]
    [InlineData(6, new[] { 3, 10, 2, 7 }, 20)] 
    [InlineData(7, new[] { 1, 3, 5, 12 }, 18)]
    public void CalculateMinimumCost_ReturnsCorrectCost_WithTwoSuppliers(int n, int[] supplierData, int expectedCost)
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>
        {
            (supplierData[0], supplierData[1]),
            (supplierData[2], supplierData[3])
        };

        output.WriteLine($"Test Case: Need {n} pairs of socks");
        foreach (var supplier in suppliers)
        {
            output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
        }

        // Act
        var result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
        
        output.WriteLine($"Calculated cost: {result}, Expected cost: {expectedCost}");

        // Assert
        Assert.Equal(expectedCost, result);
    }

    [Fact]
    public void CalculateMinimumCost_CanHandleEdgeCases()
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>
        {
            (1, 1)
        };

        output.WriteLine("Edge case with 1 supplier offering 1 pair for 1 cost");

        // Act
        var resultForOneSock = SocksPurchaseService.CalculateMinimumCost(1, suppliers);
        output.WriteLine($"For 1 sock: Calculated cost = {resultForOneSock}, Expected cost = 1");

        var resultForTenSocks = SocksPurchaseService.CalculateMinimumCost(10, suppliers);
        output.WriteLine($"For 10 socks: Calculated cost = {resultForTenSocks}, Expected cost = 10");

        // Assert
        Assert.Equal(1, resultForOneSock);  
        Assert.Equal(10, resultForTenSocks); 
    }
    
    [Fact]
    public void CalculateMinimumCost_ThrowsException_WhenSocksNumberIsInvalid()
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)> { (10, 8), (5, 4) };

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            SocksPurchaseService.CalculateMinimumCost(0, suppliers));

        Assert.Equal("The number of socks should be greater than zero. (Parameter 'n')", exception.Message);
    }

    [Fact]
    public void CalculateMinimumCost_ThrowsException_WhenSuppliersListIsEmpty()
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>();

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            SocksPurchaseService.CalculateMinimumCost(10, suppliers));

        Assert.Equal("Suppliers list cannot be empty.", exception.Message);
    }
    
    [Theory]
    [InlineData(0, new int[] { 10, 8, 5, 4, 3, 6 }, "The number of socks should be greater than zero.")]
    [InlineData(10, new int[] { }, "Suppliers list cannot be empty.")]
    [InlineData(-5, new int[] { 2, 5, 3, 9, 4, 7 }, "The number of socks should be greater than zero.")]
    public void CalculateMinimumCost_ThrowsException_WithThreeSuppliers_AdditionalCases(int n, int[] supplierData, string expectedMessage)
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>();
        
        for (int i = 0; i < supplierData.Length; i += 2)
        {
            suppliers.Add((supplierData[i], supplierData[i + 1]));
        }
        
        if (suppliers.Count > 0)
        {
            output.WriteLine($"Test Case: Need {n} pairs of socks");
            foreach (var supplier in suppliers)
            {
                output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
            }
        }
        else
        {
            output.WriteLine($"Test Case: Need {n} pairs of socks with no suppliers.");
        }

        // Act & Assert
        var exception = Assert.ThrowsAny<Exception>(() =>
            SocksPurchaseService.CalculateMinimumCost(n, suppliers));
        
        output.WriteLine($"Expected exception message: \"{expectedMessage}\", Actual exception message: \"{exception.Message}\"");
        
        if (n <= 0)
        {
            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Contains(expectedMessage, exception.Message);
        }
        else if (supplierData.Length is 0)
        {
            Assert.IsType<ArgumentException>(exception);
            Assert.Contains(expectedMessage, exception.Message);
        }
    }

}
