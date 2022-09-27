using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ServiceHost.Attributes;

public class MaxFileSize : ValidationAttribute, IClientModelValidator
{
    public long MaxSizeInMB { get; set; }

    public override bool IsValid(object? value)
    {
        var formFile = value as IFormFile;

        if (formFile == null)
            return true;

        if (formFile.Length > (MaxSizeInMB * 1024 * 1024))
            return false;

        return true;

    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context.Attributes.ContainsKey("data-val") == false)
        {
            context.Attributes.Add("data-val", "true");
        }

        string message = $"Your file size is over the limit. Your file size must be less than {MaxSizeInMB} MB";
        context.Attributes.Add("data-val-maxFileSize", ErrorMessage?.Replace("{0}", MaxSizeInMB.ToString()) ?? message);
        context.Attributes.Add("maxFileSize-value", MaxSizeInMB.ToString());

    }
}