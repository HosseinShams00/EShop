using BaseFramwork.Application.Exceptions;
using InventoryManager.Applicaton.Contracts.InventoryAgg;
using InventoryManager.Applicaton.Contracts.InventoryAgg.Command;
using InventoryManager.Applicaton.Contracts.InventoryOperationAgg.Command;
using InventoryManager.Domain.InventoryAgg;
using InventoryManager.Domain.InventoryOperationAgg;

namespace InventoryManager.Application;

public class InventoryApplication : IInventoryApplication
{
    private readonly IInventoryRepository _Repository;

    public InventoryApplication(IInventoryRepository repository)
    {
        _Repository = repository;
    }

    public void AddNewOperation(CreateInventoryOperationCommand operationCommand)
    {
        var entity = _Repository.GetBy(operationCommand.InventoryId);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.AddNewTransAction(new InventoryOperation(
            operationCommand.Count, operationCommand.OperatorId,
            operationCommand.CurrentCount, operationCommand.Description,
            operationCommand.OrderId, operationCommand.InventoryId));

        _Repository.UpdateEntity(entity);
    }

    public void Create(CreateInventoryCommand command)
    {
        _Repository.Create(new Inventory(command.ProductId, command.UnitPrice));
    }

    public void Update(EditInventoryCommand editProduct)
    {
        var entity = _Repository.GetBy(editProduct.Id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.Edit(editProduct.UnitPrice);
        _Repository.UpdateEntity(entity);
    }

}
