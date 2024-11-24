using System.Numerics;

namespace App.Api.Models;

public class FirstLabModel
{
    public int InputNumber { get; set; } 

    public BigInteger? Result { get; set; }
    
    public string ErrorMessage { get; set; } = string.Empty;
}