using App;
using Xunit.Abstractions;

namespace Tests;

public class TaskSolverTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TaskSolverTest(
        ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test_ExitReachableWithoutKeys()
    {
        // Arrange
        int rows = 3, cols = 3;
        int[] keyPrices = { 1, 1, 1, 1 };
        char[] labyrinth = {
            'S', '.', 'E',
            '.', 'X', '.',
            'X', '.', 'X'
        };
        var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCostToExit((0, 0));

        // Assert
        _testOutputHelper.WriteLine("Result: " + result);
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_ExitWithOneKeyRequired()
    {
        // Arrange
        int rows = 4, cols = 4;
        int[] keyPrices = { 2, 3, 1, 4 };
        char[] labyrinth = {
            'S', 'R', '.', '.',
            'X', 'X', '.', 'B',
            'X', 'X', '.', '.',
            'X', '.', '.', 'E'
        };
        var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCostToExit((0, 0));

        // Assert
        _testOutputHelper.WriteLine("Result: " + result);
        Assert.Equal(2, result); 
    }

    [Fact]
    public void Test_ExitWithMultipleKeys()
    {
        // Arrange
        int rows = 5, cols = 5;
        int[] keyPrices = { 1, 2, 3, 4 };
        char[] labyrinth = {
            'S', '.', 'X', 'G', 'E',
            'X', '.', '.', '.', 'B',
            'X', 'X', '.', 'X', 'X',
            'X', 'X', 'Y', '.', 'R',
            'X', 'X', 'X', '.', '.'
        };
        var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCostToExit((0, 0));

        // Assert
        _testOutputHelper.WriteLine("Result: " + result);
        Assert.Equal(2, result); 
    }

    [Fact]
    public void Test_NoExitAvailable()
    {
        // Arrange
        int rows = 3, cols = 3;
        int[] keyPrices = { 5, 5, 5, 5 };
        char[] labyrinth = {
            'S', 'X', 'X',
            'X', 'X', 'X',
            'X', 'X', 'E'
        };
        var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCostToExit((0, 0));

        // Assert
        _testOutputHelper.WriteLine("Result: " + result);
        Assert.Equal(-1, result); 
    }

    [Fact]
    public void Test_ComplexLabyrinthWithMinimumKeys()
    {
        // Arrange
        int rows = 6, cols = 6;
        int[] keyPrices = { 1, 5, 3, 1 };
        char[] labyrinth = {
            'X', 'X', 'X', 'X', 'X', 'X',
            'X', 'S', '.', 'X', '.', 'X',
            'X', '.', '.', 'R', '.', 'X',
            'X', '.', 'X', 'X', 'B', 'X',
            'X', 'G', '.', 'E', '.', 'X',
            'X', 'X', 'X', 'X', 'X', 'X'
        };
        var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCostToExit((1, 1));

        // Assert
        _testOutputHelper.WriteLine("Result: " + result);
        Assert.Equal(5, result);
    }
}