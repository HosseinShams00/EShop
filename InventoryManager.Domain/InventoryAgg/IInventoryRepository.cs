﻿using BaseFramework.Repository;

namespace InventoryManager.Domain.InventoryAgg;

public interface IInventoryRepository : IBaseRepository<long, Inventory>
{
}

