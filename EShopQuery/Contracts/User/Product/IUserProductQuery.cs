namespace EShopQuery.Contracts.User.Product;

public interface IUserProductQuery
{
    List<UserProductQueryModel> GetLastProductsQueryModels();
    List<UserProductQueryModel> Search(string productName);
    UserProductQueryModel? GetProductQueryModelFull(long productId);
}