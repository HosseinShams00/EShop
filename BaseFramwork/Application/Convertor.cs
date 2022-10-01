namespace BaseFramework.Application;

public class Convertor
{
    public static T Convert<T>(object input) where T : class
    {
        var instance = Activator.CreateInstance<T>();
        var propertyInfosResult = instance.GetType().GetProperties();
        var propertyInfosInput = input.GetType().GetProperties();

        foreach (var propertyInfo in propertyInfosInput)
        {
            var propertyRes = propertyInfosResult.FirstOrDefault(x => x.Name == propertyInfo.Name);
            if (propertyRes != null)
            {
                propertyRes.SetValue(propertyInfo.GetValue(input), instance);
            }
        }

        return instance;
    }

    public static void Copy(object source, object destination)
    {
        var propertyInfosSrc = source.GetType().GetProperties();
        var propertyInfosDes = destination.GetType().GetProperties();

        foreach (var propertyInfoSrc in propertyInfosSrc)
        {
            var propertyDes = propertyInfosDes.FirstOrDefault(x => x.Name == propertyInfoSrc.Name);
            if (propertyDes != null)
            {
                propertyDes.SetValue(propertyInfoSrc.GetValue(source), destination);
            }
        }
    }
}
