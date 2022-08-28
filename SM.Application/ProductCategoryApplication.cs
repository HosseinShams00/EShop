using ShopManagement.Application.Constracts.ProductCategroy;
using ShopManagement.Application.Constracts.ProductCategroy.Command;
using BaseFramwork.Application;
using _0_Framework.Application;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository ProductCategoryRepository;

    public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
    {
        ProductCategoryRepository = productCategoryRepository;
    }

    public OperationResult Create(CreateProductCategory createProductCategory)
    {
        OperationResult operationResult = new();
        if (ProductCategoryRepository.Exist(x => x.Name == createProductCategory.Name))
            return operationResult.Faild("این نام وجود دارد.");

        var productCategory = new ProductCategory(createProductCategory.Name, createProductCategory.Description,
            createProductCategory.Picture, createProductCategory.PictureAlt,
            createProductCategory.PictureTitle, createProductCategory.Keywords,
            createProductCategory.MetaDescription, createProductCategory.Slug.ModifySlug());

        ProductCategoryRepository.Create(productCategory);
        ProductCategoryRepository.SaveChanges();
        return operationResult.Success();
    }

    public OperationResult Update(EditProductCategory editProductCategory)
    {
        OperationResult operationResult = new();
        var productCategory = ProductCategoryRepository.GetBy(editProductCategory.Id);

        if (productCategory is null)
            return operationResult.Faild("اطلاعات مورد نظر یافت نشد");

        if(ProductCategoryRepository.Exist(x => x.Name == editProductCategory.Name && x.Id != editProductCategory.Id))
            return operationResult.Faild("نام ثبت شده تکراری است لطفا مجدد تلاش کنید");

        productCategory.Edit(editProductCategory.Name, editProductCategory.Description,
            editProductCategory.Picture, editProductCategory.PictureAlt,
            editProductCategory.PictureTitle, editProductCategory.Keywords,
            editProductCategory.MetaDescription, editProductCategory.Slug.ModifySlug());

        ProductCategoryRepository.SaveChanges();
        return operationResult.Success();
    }

    public EditProductCategory GetDetail(long id)
    {
        return ProductCategoryRepository.GetDetail(id);
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel productCategorySearchModel)
    {
        return ProductCategoryRepository.Search(productCategorySearchModel);
    }

}