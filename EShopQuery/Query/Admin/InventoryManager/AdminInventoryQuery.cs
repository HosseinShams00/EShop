using EShopQuery.Contracts.Admin.InventoryManager;
using InventoryManager.Application.Contract.InventoryAgg.Command;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.Admin.InventoryManager;

public class AdminInventoryQuery : IAdminInventoryQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminInventoryQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditInventoryCommand? GetDetails(long id)
    {
        return _context.InventoryQueries
            .Select(x => new EditInventoryCommand()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice

            })
            .FirstOrDefault(x => x.Id == id);
    }

    public long GetInventoryIdWith(long productId)
    {
        return _context.InventoryQueries
            .Where(x => x.ProductId == productId)
            .Select(x => x.Id)
            .FirstOrDefault();
    }

    public List<InventoryOperationQueryModel> GetOperationViewModels(long inventoryId)
    {
        return _context.InventoryOperationQueries
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
        var viewModels = _context.InventoryQueries
            .Select(x => new InventoryQueryModel()
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                ProductName = x.ProductQuery.Name
            })
            .ToList();
        
        return viewModels;
    }

    public List<InventoryQueryModel> GetViewModels(InventorySearchModel searchModel)
    {
        var viewModelsQuery = _context.InventoryQueries
            .Select(x => new InventoryQueryModel()
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                ProductName = x.ProductQuery.Name
            });

        if (searchModel.ProductId != 0)
            viewModelsQuery = viewModelsQuery.Where(x => x.ProductId == searchModel.ProductId);

        if (searchModel.InStock)
            viewModelsQuery = viewModelsQuery.Where(x => x.CurrentCount > 0);
        else
            viewModelsQuery = viewModelsQuery.Where(x => x.CurrentCount <= 0);


        return viewModelsQuery.ToList();
    }
}
