namespace GeekShopping.ProductAPI.Model.Product
{
    public record ProductRequest(string Name, decimal Price, string Description, string Category, string ImageUrl);
}
