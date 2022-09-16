﻿using BaseFramwork.Domain;
using DiscountManager.Domain.CustomerDiscountAgg;
using System.ComponentModel.DataAnnotations;

namespace DiscountManager.Domain.ProductCustomerDiscountAgg;

public class ProductCustomerDiscount : ProductCustomerDiscountBase
{
    public long ProductId { get; set; }
    public long CustomerDiscountId { get; private set; }
    public CustomerDiscount CustomerDiscount { get; private set; }
    protected ProductCustomerDiscount()
    {

    }

    public ProductCustomerDiscount(long productId, long customerDiscountId , IProductCustomerDiscountValidator validator)
    {
        validator.CheckProductId(productId);
        ProductId = productId;

        validator.CheckCustomerDiscountId(customerDiscountId);
        CustomerDiscountId = customerDiscountId;
    }

    public void EditCustomerDiscountId(long customerDiscountId, IProductCustomerDiscountValidator validator)
    {
        validator.CheckCustomerDiscountId(customerDiscountId);
        CustomerDiscountId = customerDiscountId;
    }
}