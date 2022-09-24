namespace EShopQuery.Contracts.User.ProductCategories;

public interface IUserProductCategoryQuery
{
    List<UserProductCategoriesQuery> GetViewModels();
    List<UserProductCategoriesQuery> GetViewModelsWithProduct();
}
