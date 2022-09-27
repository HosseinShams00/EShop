using DiscountManager.Infrastructure.EFCore;
using InventoryManager.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace EShopQuery.Query.User;

public static class ProductHelper
{
    public static bool ProductIsInStock(long productId, InventoryEFCoreDbContext inventoryEfCoreDbContext)
    {
        return inventoryEfCoreDbContext.Inventories
            .Where(x => x.ProductId == productId)
            .Select(x => x.CurrentCount > 0)
            .FirstOrDefault();
    }

    public static int GetProductPrice(long productId, InventoryEFCoreDbContext inventoryEfCoreDbContext)
    {
        return inventoryEfCoreDbContext.Inventories
            .Where(x => x.ProductId == productId)
            .Select(x => x.UnitPrice)
            .FirstOrDefault();
    }

    public static int GetProductDiscountValue(long productId, DiscountManagerEFCoreDbContext discountManagerEfCoreDbContext)
    {
        return discountManagerEfCoreDbContext.ProductCustomerDiscounts
            .Include(x => x.CustomerDiscount)
            .Where(x => x.ProductId == productId 
                        && x.CustomerDiscount.EndDateTime > DateTime.Now)
            .Select(x => x.CustomerDiscount.DiscountPercent)
            .FirstOrDefault();
    }

    public static DateTime GetProductDiscountExpireDateTime(long productId, DiscountManagerEFCoreDbContext discountManagerEfCoreDbContext)
    {
        return discountManagerEfCoreDbContext.ProductCustomerDiscounts
            .Include(x => x.CustomerDiscount)
            .Where(x => x.ProductId == productId)
            .Select(x => x.CustomerDiscount.EndDateTime)
            .FirstOrDefault();
    }

    public static int CalculateDiscount(int price, int discount)
    {
        double dis = 100 - discount;
        dis /= 100;
        return (int)(price * dis);
    }
}