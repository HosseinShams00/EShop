namespace BaseFramework.Application;

public class Convertor
{
    public static T Convert<T>(object input) where T : class
    {
        var instance = Activator.CreateInstance<T>();
        Copy(input, instance);
        return instance;
    }

    public static void Copy(object? source, object? destination)
    {
        if (source == null || destination == null)
            return;

        var propertyInfosSrc = source.GetType().GetProperties();
        var propertyInfosDes = destination.GetType().GetProperties();

        foreach (var propertyInfoSrc in propertyInfosSrc)
        {
            var propertyDes = propertyInfosDes.FirstOrDefault(x => x.Name == propertyInfoSrc.Name);
            if (propertyDes != null)
            {
                if (propertyInfoSrc.PropertyType == propertyDes.PropertyType)
                {
                    propertyDes.SetValue(destination, propertyInfoSrc.GetValue(source));
                }

            }
        }
    }
}
