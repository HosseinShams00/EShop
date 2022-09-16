using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Exceptions;

namespace ShopManagement.Application.ProductPictureAgg;

public class ProductPictureApplication : IProductPictureApplication
{
    private readonly IProductPictureRepository ProductPictureRepository;
    private readonly IProductPictureValidator Validator;

    public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductPictureValidator validator)
    {
        ProductPictureRepository = productPictureRepository;
        Validator = validator;
    }

    public void Create(CreateProductPicture createProductCategory)
    {
        try
        {
            var productPicture = new ProductPicture(createProductCategory.Path, createProductCategory.PictureAlt,
                createProductCategory.PictureTitle, createProductCategory.ProductId, Validator);

            ProductPictureRepository.Create(productPicture);
        }
        catch (Exception ex)
        {

        }
    }

    public void Delete(long id)
    {
        var picture = ProductPictureRepository.GetBy(id);
        if (picture == null)
            throw new EntityNotFoundException();

        picture.DeActive();
        ProductPictureRepository.UpdateEntity(picture);
    }

    public List<ProductPictureViewModel> GetAll()
    {
        return ProductPictureRepository.GetViewModels();
    }

    public EditProductPicture GetDetail(long id)
    {
        var picture = ProductPictureRepository.GetDetail(id);
        if (picture is null)
            throw new EntityNotFoundException();

        return picture;
    }

    public void Restore(long id)
    {
        var picture = ProductPictureRepository.GetBy(id);
        if (picture == null)
            throw new EntityNotFoundException();

        picture.Active();
        ProductPictureRepository.UpdateEntity(picture);
    }

    public void Update(EditProductPicture editProductCategory)
    {
        try
        {
            var picture = ProductPictureRepository.GetBy(editProductCategory.Id);
            if (picture == null)
                throw new EntityNotFoundException();

            picture.Edit(editProductCategory.Path, editProductCategory.PictureAlt,
            editProductCategory.PictureTitle, editProductCategory.ProductId, Validator);

            ProductPictureRepository.UpdateEntity(picture);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductPictureAgg.Exceptions.ProductIdNotExistException)
                throw new ProductIdNotExistException();
        }
    }
}
