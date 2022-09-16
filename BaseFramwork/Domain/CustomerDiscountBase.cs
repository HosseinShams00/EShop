namespace BaseFramwork.Domain;

public class CustomerDiscountBase
{
    public long Id { get; private set; }
    public DateTime CreationDateTime { get; private set; }
    public bool IsRemoved { get; private set; }

    public CustomerDiscountBase()
    {
        CreationDateTime = DateTime.Now;
    }

    public void Active() => IsRemoved = false;
    public void DeActive() => IsRemoved = true;
}
