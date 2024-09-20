namespace GeekShopping.ProductAPI.Model.Base
{
    public class BaseEntity
    {
        public Guid Id{ get; set; }


        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
