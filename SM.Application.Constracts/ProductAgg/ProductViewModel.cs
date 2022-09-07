namespace ShopManagement.Application.Constracts.ProductAgg
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreationTime { get; set; }
        public bool IsRemoved { get; set; }

    }
}