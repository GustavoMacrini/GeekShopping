namespace GeekShopping.ProductAPI.Model.Product
{
    public record ProductResponse(Guid Id, string Name, decimal Price, string Description, string Category, string ImageUrl);

}
