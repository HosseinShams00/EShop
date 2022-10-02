using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using InventoryManager.Applicaton.Contract.InventoryAgg;
using InventoryManager.Applicaton.Contract.InventoryAgg.Command;
using InventoryManager.Applicaton.Contract.InventoryOperationAgg.Command;
using InventoryManager.Domain.InventoryAgg;
using InventoryManager.Domain.InventoryOperationAgg;
using SecondaryDB.Domain;

namespace InventoryManager.Application;

public class InventoryApplication : IInventoryApplication
{
    private readonly IInventoryRepository _repository;
    private readonly IInventoryQueryRepository _inventoryQueryRepository;

    public InventoryApplication(IInventoryRepository repository,
        IInventoryQueryRepository inventoryQueryRepository)
    {
        _repository = repository;
        _inventoryQueryRepository = inventoryQueryRepository;
    }

    public void AddNewOperation(CreateInventoryOperationCommand operationCommand)
    {
        var entity = _repository.GetBy(operationCommand.InventoryId);
        if (entity == null)
            throw new EntityNotFoundException();


        entity.AddNewTransAction(new InventoryOperation(
            operationCommand.Count, operationCommand.OperatorId,
            entity.CurrentCount, operationCommand.Description,
            operationCommand.OrderId, operationCommand.InventoryId));

        _repository.UpdateEntity(entity);

        var entityQuery = _inventoryQueryRepository.Get(x => x.Id == entity.Id);
        entityQuery.CurrentCount = entity.CurrentCount;
        foreach (var inventoryOperation in entity.Operations)
        {
            entityQuery.InventoryOperationQueries.Add(Convertor.Convert<InventoryOperationQuery>(inventoryOperation));
        }

        _inventoryQueryRepository.UpdateEntity(entityQuery);
    }

    public void Create(CreateInventoryCommand command)
    {
        var inventory = new Inventory(command.ProductId, command.UnitPrice);
        _repository.Create(inventory);

        var inventoryQuery = Convertor.Convert<InventoryQuery>(inventory);
        _inventoryQueryRepository.Create(inventoryQuery);

    }

    public void Update(EditInventoryCommand editProduct)
    {
        var entity = _repository.GetBy(editProduct.Id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.Edit(editProduct.UnitPrice);
        _repository.UpdateEntity(entity);

        var entityQuery = _inventoryQueryRepository.Get(x => x.Id == entity.Id);
        entityQuery.UnitPrice = entity.UnitPrice;
        _inventoryQueryRepository.UpdateEntity(entityQuery);
    }

}
