namespace ShopManagement.Domain.ProductAgg;

public class LaptopProduct
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ShortDecription { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
    public string BrandName { get; private set; }
    public int CpuCore { get; private set; }
    public int CpuCount { get; private set; }
    public int NumberOfRamSlot { get; private set; }
    public int DiskSpace { get; private set; }
    public int UnitPrice { get; private set; }
    public string DiskType { get; private set; }
    public int MonitorSize { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int WarehouseStock { get; private set; }
    public string OtherOptions { get; private set; }
    public bool IsInStock { get; private set; }
    public List<string> ColorNames { get; set; }


    protected LaptopProduct()
    {

    }

    public LaptopProduct(string name, string description,
        string shortDecription, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, string brandName,
        int cpuCore, int cpuCount,
        int numberOfRamSlot, int diskSpace,
        int unitPrice, string diskType,
        int monitorSize, int width,
        int height, string otherOptions,
        bool isInStock, List<string> colorNames, int warehouseStock)
    {
        Name = name;
        Description = description;
        ShortDecription = shortDecription;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
        BrandName = brandName;
        CpuCore = cpuCore;
        CpuCount = cpuCount;
        NumberOfRamSlot = numberOfRamSlot;
        DiskSpace = diskSpace;
        UnitPrice = unitPrice;
        DiskType = diskType;
        MonitorSize = monitorSize;
        Width = width;
        Height = height;
        OtherOptions = otherOptions;
        IsInStock = isInStock;
        ColorNames = colorNames;
        CreationTime = DateTime.Now;
        WarehouseStock = warehouseStock;
    }

    public void Edit(string name, string description,
        string shortDecription, string picture,
        string pictureAlt, string pictureTitle,
        string keywords, string metaDescription,
        string slug, string brandName,
        int cpuCore, int cpuCount,
        int numberOfRamSlot, int diskSpace,
        int unitPrice, string diskType,
        int monitorSize, int width,
        int height, string otherOptions,
        bool isInStock, List<string> colorNames , int warehouseStock)
    {
        Name = name;
        Description = description;
        ShortDecription = shortDecription;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        Keywords = keywords;
        MetaDescription = metaDescription;
        Slug = slug;
        BrandName = brandName;
        CpuCore = cpuCore;
        CpuCount = cpuCount;
        NumberOfRamSlot = numberOfRamSlot;
        DiskSpace = diskSpace;
        UnitPrice = unitPrice;
        DiskType = diskType;
        MonitorSize = monitorSize;
        Width = width;
        Height = height;
        OtherOptions = otherOptions;
        IsInStock = isInStock;
        ColorNames = colorNames;
        WarehouseStock = warehouseStock;
    }
}

