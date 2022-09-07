namespace BaseFramwork.Domain;

public class SliderBase
{
    public long Id { get; private set; }
    public DateTime CreationTime { get; private set; }
    public bool IsRemoved { get; private set; }

    public SliderBase()
    {
        CreationTime = DateTime.Now;
    }

    public void Active() => IsRemoved = false;
    public void DeActive() => IsRemoved = true;
}