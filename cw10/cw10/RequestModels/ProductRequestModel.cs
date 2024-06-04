namespace cw10.RequestModels;

public class ProductRequestModel
{
    public string ProductName { get; set; }
    public Decimal ProductWeight { get; set; }
    public Decimal ProductWidth { get; set; }
    public Decimal ProductHeight { get; set; }
    public Decimal ProductDepth { get; set; }
    public ICollection<int> ProductCategories { get; set; }
}