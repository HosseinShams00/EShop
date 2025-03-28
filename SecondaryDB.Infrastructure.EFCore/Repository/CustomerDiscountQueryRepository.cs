﻿using BaseFramework.Repository;
using SecondaryDB.Domain.CustomerDiscountQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Repository;

public class CustomerDiscountQueryRepository : BaseQueryRepository<long, CustomerDiscountQuery>, ICustomerDiscountQueryRepository
{
    public CustomerDiscountQueryRepository(SecondaryDBEfCoreContext context) : base(context)
    {
    }
}
