namespace EShopQuery.Contracts.User.Product;

public interface IUserProductQuery
{
    List<UserProductQueryModel> GetLastProductsQueryModels();
}