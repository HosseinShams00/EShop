using BaseFramework.Domain;

namespace DiscountManager.Domain.CustomerDiscountAgg;

public interface ICustomerDiscount : IBaseDomain
{
    public string Title { get;  }
    public string? Description { get;  }
    public DateTime StartDateTime { get;  }
    public DateTime EndDateTime { get;  }
    public int DiscountPercent { get;  }
}