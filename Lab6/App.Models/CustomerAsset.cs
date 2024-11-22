namespace App.Models;

public class CustomerAsset
{
    public int CustomerAssetId { get; set; }
    
    public int CustomerId { get; set; }
    
    public int AssetTypeCode { get; set; }
    
    public DateTime DateAssetAcquired { get; set; }

    public CustomerProfile Customer { get; set; }
    
    public RefAssetType RefAssetType { get; set; }
}