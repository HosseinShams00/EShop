using EShopQuery.Contracts.Slider;

namespace EShopQuery.Contracts.ProductCategories;

public interface IProductCategoryQuery
{
    List<ProductCategoriesQueryViewModels> GetViewModels();
}
