namespace BaseFramework.Domain.BaseDomainAgg;

public interface IBaseDomain
{
    public long Id { get; }
    public DateTime CreationTime { get; }
    public bool IsRemoved { get; }
}