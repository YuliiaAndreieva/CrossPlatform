namespace App;

public class Exceptions
{
    public class InputException(string message) : Exception (message) { }
}