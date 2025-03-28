﻿using ShopManagement.Application.Contract.ProductAgg.Command;

namespace EShopQuery.Contracts.Admin.Product;

public interface IAdminProductQuery
{
    EditProduct GetDetail(long id);
    List<ProductQueryModel> Search(ProductSearchModel productSearchModel);
    List<ProductQueryModel> GetViewModels();
}
