using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Application.Constracts.ProductPictureAgg.Exceptions;

namespace ShopManagement.Application.ProductPictureAgg;

public class ProductPictureApplication : IProductPictureApplication
{
    private readonly IProductPictureRepository ProductPictureReository;
    private readonly IProductPictureValidator Validator;

    public ProductPictureApplication(IProductPictureRepository productPictureReository, IProductPictureValidator validator)
    {
        ProductPictureReository = productPictureReository;
        Validator = validator;
    }

    public void Create(CreateProductPicture createProductCategory)
    {
        try
        {
            var productPicture = new ProductPicture(createProductCategory.Path, createProductCategory.PictureAlt,
                createProductCategory.PictureTitle, createProductCategory.ProductId, Validator);

            ProductPictureReository.Create(productPicture);
        }
        catch (Exception ex)
        {

        }
    }

    public void Delete(long id)
    {
        var picture = ProductPictureReository.GetBy(id);
        if (picture == null)
            throw new EntityNotFoundException();

        picture.DeActive();
        ProductPictureReository.SaveChanges(picture);
    }

    public List<ProductPictureViewModel> GetAll()
    {
        return ProductPictureReository.GetViewModels();
    }

    public EditProductPicture GetDetail(long id)
    {
        var picture = ProductPictureReository.GetDetail(id);
        if (picture is null)
            throw new EntityNotFoundException();

        return picture;
    }

    public void Restore(long id)
    {
        var picture = ProductPictureReository.GetBy(id);
        if (picture == null)
            throw new EntityNotFoundException();

        picture.Active();
        ProductPictureReository.SaveChanges(picture);
    }

    public void Update(EditProductPicture editProductCategory)
    {
        try
        {
            var picture = ProductPictureReository.GetBy(editProductCategory.Id);
            if (picture == null)
                throw new EntityNotFoundException();

            picture.Edit(editProductCategory.Path, editProductCategory.PictureAlt,
            editProductCategory.PictureTitle, editProductCategory.ProductId, Validator);

            ProductPictureReository.SaveChanges(picture);
        }
        catch (Exception ex)
        {
            if (ex is Domain.ProductPictureAgg.Exceptions.ProductIdNotExistException)
                throw new ProductIdNotExistException();
        }
    }
}
