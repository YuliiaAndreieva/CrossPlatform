namespace App.Models;

public class RefAssetType
{
    public int AssetTypeCode { get; set; }
    
    public string AssetTypeDescription { get; set; }
    

    public ICollection<CustomerAsset> CustomerAssets { get; set; }
}