using BaseFramework.Domain.BaseDomainAgg;

namespace AccountManager.Domain.AccountAgg;

public interface IAccount : IBaseDomain
{
    public string FirstName { get; }
    public string LastName { get; }
    public string UserName { get; }
    public long PhoneNumber { get; }
    public int? RoleId { get; }
    public string Email { get; }
    public string Password { get; }
    public bool IsEmailConfirmed { get; }
    public bool IsPhoneNumberConfirmed { get; }
}