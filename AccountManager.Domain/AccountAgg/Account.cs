using BaseFramework.Domain.BaseDomainAgg;

namespace AccountManager.Domain.AccountAgg;

public class Account : BaseDomain, IAccount
{

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public long PhoneNumber { get; private set; }
    public int? RoleId { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsEmailConfirmed { get; private set; }
    public bool IsPhoneNumberConfirmed { get; private set; }

    public Account(string firstName, string lastName,
        string userName, long phoneNumber,
        int? roleId, string email,
        string password)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        PhoneNumber = phoneNumber;
        RoleId = roleId;
        Email = email;
        Password = password;
        IsEmailConfirmed = false;
        IsPhoneNumberConfirmed = false;
    }

    public void Edit(string firstName, string lastName,
        string userName, int? roleId)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        RoleId = roleId;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public void ConfirmEmail()
    {
        IsEmailConfirmed = true;
    }

    public void ConfirmPhoneNumber()
    {
        IsPhoneNumberConfirmed = true;
    }
}