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
}
