using BaseFramework.Domain.BaseDomainAgg;

namespace ShopManagement.Domain.ProductPictureAgg;

public interface IProductPicture : IBaseDomain
{
    public string Path { get; }
    public string? PictureAlt { get; }
    public string? PictureTitle { get; }
    public long ProductId { get; }
}