using BaseFramework.Application.Exceptions;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Application.Contract.ProductPictureAgg.Exceptions;
using BaseFramework.Application;
using ShopManagement.Application.Contract.ProductPictureAgg.Command;
using ShopManagement.Application.Contract.ProductPictureAgg;
using SecondaryDB.Domain.ProductPictureQueryAgg;

namespace ShopManagement.Application.ProductPictureAgg;

public class ProductPictureApplication : IProductPictureApplication
{
    private readonly IProductPictureRepository _productPictureRepository;
    private readonly IProductPictureValidator _validator;
    private readonly IProductPictureQueryRepository _productPictureQueryRepository;

    public ProductPictureApplication(IProductPictureRepository productPictureRepository,
        IProductPictureValidator validator,
        IProductPictureQueryRepository productPictureQueryRepository)
    {
        _productPictureRepository = productPictureRepository;
        _validator = validator;
        _productPictureQueryRepository = productPictureQueryRepository;
    }

    public void Create(CreateProductPicture createProductPicture)
    {
        try
        {
            var entity = new ProductPicture(createProductPicture.Path, createProductPicture.PictureAlt,
                createProductPicture.PictureTitle, createProductPicture.ProductId, _validator);

            _productPictureRepository.Create(entity);

            var productPictureQuery = Convertor.Convert<ProductPictureQuery>(entity);
            _productPictureQueryRepository.Create(productPictureQuery);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Delete(long id)
    {
        var entity = _productPictureRepository.GetBy(id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.DeActive();
        _productPictureRepository.UpdateEntity(entity);

        var productPictureQuery = _productPictureQueryRepository.Get(x => x.Id == entity.Id);
        productPictureQuery.IsRemoved = true;
        _productPictureQueryRepository.UpdateEntity(productPictureQuery);
    }

    public void Restore(long id)
    {
        var entity = _productPictureRepository.GetBy(id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.Active();
        _productPictureRepository.UpdateEntity(entity);

        var productPictureQuery = _productPictureQueryRepository.Get(x => x.Id == entity.Id);
        productPictureQuery.IsRemoved = false;
        _productPictureQueryRepository.UpdateEntity(productPictureQuery);
    }

    public void Update(EditProductPicture editProductPicture)
    {
        try
        {
            var entity = _productPictureRepository.GetBy(editProductPicture.Id);
            if (entity == null)
                throw new EntityNotFoundException();

            entity.Edit(editProductPicture.Path, editProductPicture.PictureAlt,
            editProductPicture.PictureTitle, editProductPicture.ProductId, _validator);

            _productPictureRepository.UpdateEntity(entity);

            var productPictureQuery = _productPictureQueryRepository.Get(x => x.Id == entity.Id);
            Convertor.Copy(productPictureQuery, entity);
            _productPictureQueryRepository.UpdateEntity(productPictureQuery);

        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductPictureAgg.Exceptions.ProductIdNotExistException)
                throw new ProductIdNotExistException();

            throw;
        }
    }
}
