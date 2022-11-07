using BaseFramework.Repository;

namespace AccountManager.Domain.AccountAgg;

public interface IAccountRepository : IBaseAccountRepository<long, Account>
{
}