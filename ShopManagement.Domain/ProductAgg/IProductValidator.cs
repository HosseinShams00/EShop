namespace ShopManagement.Domain.ProductAgg;

public interface IProductValidator
{
    void CheckNameExist(string name);
    void CheckNameExistWithId(string name, long id);
    void CheckCategoryIdExist(long id);
}
