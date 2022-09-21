namespace EShopQuery.Contracts.Admin.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreationTime { get; set; }
        public bool IsRemoved { get; set; }
        public long InventoryId { get; set; }

    }
}