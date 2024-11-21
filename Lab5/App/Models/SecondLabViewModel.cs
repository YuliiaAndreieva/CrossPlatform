namespace App.Models;

public class SecondLabViewModel
{
    public int TotalSocks { get; set; } 
    
    public int SupplierCount { get; set; } 
    
    public List<SupplierModel> Suppliers { get; set; } = new();
    
    public int? Result { get; set; } 
    
    public string? ErrorMessage { get; set; } 
    
    public class SupplierModel
    {
        public int Packs { get; set; }
        
        public int Price { get; set; }
    }
}