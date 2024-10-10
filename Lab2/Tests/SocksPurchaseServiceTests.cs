using App;
using Xunit.Abstractions;

namespace Tests;

public class SocksPurchaseServiceTests
{
    private readonly ITestOutputHelper _output;

    public SocksPurchaseServiceTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void SortSuppliersByPrice_SortsSuppliersCorrectly()
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>
        {
            (10, 8),  
            (1, 1),   
            (5, 4),   
            (2, 5)    
        };

        _output.WriteLine("Sorting suppliers by price per pair...");
        foreach (var supplier in suppliers)
        {
            _output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
        }

        // Act
        var sortedSuppliers = SocksPurchaseService.SortSuppliersByPrice(suppliers);
        _output.WriteLine("Sorted suppliers:");
        foreach (var supplier in sortedSuppliers)
        {
            _output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
        }

        // Assert
        Assert.Equal((10, 8), sortedSuppliers[0]);  
        Assert.Equal((5, 4), sortedSuppliers[1]);   
        Assert.Equal((1, 1), sortedSuppliers[2]);  
        Assert.Equal((2, 5), sortedSuppliers[3]);  
    }

    [Theory]
    [InlineData(9, new[] { 1, 1, 10, 8 }, 8)]  
    public void CalculateMinimumCost_ReturnsCorrectCost(int n, int[] supplierData, int expectedCost)
    {
        // Arrange
        var suppliers = new List<(int ai, int bi)>
        {
            (supplierData[0], supplierData[1]),
            (supplierData[2], supplierData[3])
        };

        _output.WriteLine($"Test Case: Need {n} pairs of socks");
        foreach (var supplier in suppliers)
        {
            _output.WriteLine($"Supplier: {supplier.ai} pairs for {supplier.bi} rubles (price per pair = {(float)supplier.bi / supplier.ai})");
        }

        // Act
        var result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
        
        _output.WriteLine($"Calculated cost: {result}, Expected cost: {expectedCost}");

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

        _output.WriteLine("Edge case with 1 supplier offering 1 pair for 1 ruble");

        // Act
        var resultForOneSock = SocksPurchaseService.CalculateMinimumCost(1, suppliers);
        _output.WriteLine($"For 1 sock: Calculated cost = {resultForOneSock}, Expected cost = 1");

        var resultForTenSocks = SocksPurchaseService.CalculateMinimumCost(10, suppliers);
        _output.WriteLine($"For 10 socks: Calculated cost = {resultForTenSocks}, Expected cost = 10");

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
}
