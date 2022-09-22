using EShopQuery.Contracts.Admin.InventoryManager;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using InventoryManager.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.InventoryManager;

public class AdminInventoryQuery : IAdminInventoryQuery
{
    private readonly InventoryEFCoreDbContext _InventoryDbContext;
    private readonly ShopManagerEFCoreDbContext _ShopManagerDbContext;

    public AdminInventoryQuery(InventoryEFCoreDbContext inventoryDbContext, ShopManagerEFCoreDbContext shopManagerDbContext)
    {
        _InventoryDbContext = inventoryDbContext;
        _ShopManagerDbContext = shopManagerDbContext;
    }

    public EditInventoryCommand? GetDetails(long id)
    {
        return _InventoryDbContext.Inventories
            .Select(x => new EditInventoryCommand()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice

            })
            .FirstOrDefault(x => x.Id == id);
    }

    public long GetInventoryIdWith(long productId)
    {
        return _InventoryDbContext.Inventories
            .Where(x => x.ProductId == productId)
            .Select(x => x.Id)
            .FirstOrDefault();
    }

    public List<InventoryOperationQueryModel> GetOperationViewModels(long inventoryId)
    {
        return _InventoryDbContext.InventoryOperations
            .Where(x => x.InventoryId == inventoryId)
            .Select(x => new InventoryOperationQueryModel()
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                OperationDate = x.OperationDate,
                OperatorId = x.OperatorId,
                OrderId = x.OrderId

            })
            .ToList();
    }

    public List<InventoryQueryModel> GetViewModels()
    {
        var viewModels = _InventoryDbContext.Inventories
            .Select(x => new InventoryQueryModel()
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                ProductName = String.Empty
            })
            .ToList();

        for (int i = 0; i < viewModels.Count; i++)
        {
            viewModels[i].ProductName = _ShopManagerDbContext.Products
                                        .Where(x => x.Id == viewModels[i].ProductId)
                                        .Select(x => x.Name)
                                        .FirstOrDefault() ?? string.Empty;
        }

        return viewModels;
    }

    public List<InventoryQueryModel> GetViewModels(InventorySearchModel searchModel)
    {
        var viewModelsQuery = _InventoryDbContext.Inventories
            .Select(x => new InventoryQueryModel()
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                ProductName = String.Empty
            });

        if (searchModel.ProductId != 0)
            viewModelsQuery = viewModelsQuery.Where(x => x.ProductId == searchModel.ProductId);

        if (searchModel.InStock)
            viewModelsQuery = viewModelsQuery.Where(x => x.CurrentCount > 0);
        else
            viewModelsQuery = viewModelsQuery.Where(x => x.CurrentCount <= 0);

        var viewModels = viewModelsQuery.ToList();


        for (int i = 0; i < viewModels.Count; i++)
        {
            viewModels[i].ProductName = _ShopManagerDbContext.Products
                                        .Where(x => x.Id == viewModels[i].ProductId)
                                        .Select(x => x.Name)
                                        .FirstOrDefault() ?? string.Empty;
        }

        return viewModels;
    }
}
