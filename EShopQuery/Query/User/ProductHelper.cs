using EShopQuery.Contracts.User.Product;
using EShopQuery.Contracts.User.ProductCategories;

namespace EShopQuery.Query.User;

public static class ProductHelper
{

    public static void FillPriceWithDiscountValue(UserProductCategoriesQuery? productCategoryQueryViewModel)
    {
        foreach (var userProductQueryModel in productCategoryQueryViewModel.ProductQueryModels)
        {
            FillPriceWithDiscountValue(userProductQueryModel);
        }
    }
    public static void FillPriceWithDiscountValue(UserProductQueryModel? productQueryModel)
    {
        if (productQueryModel == null)
            return;

        productQueryModel.PriceWithDiscount = CalculateDiscount(productQueryModel.IntPrice.GetValueOrDefault(),
                                                productQueryModel.DiscountRate.GetValueOrDefault()).ToString("N0");
    }


    public static int CalculateDiscount(int price, int discount)
    {
        double dis = 100 - discount;
        dis /= 100;
        return (int)(price * dis);
    }
}