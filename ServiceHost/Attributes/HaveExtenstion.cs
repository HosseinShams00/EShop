using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ServiceHost.Attributes;

public class HaveExtenstion : ValidationAttribute, IClientModelValidator
{

    public string[] Extenstion { get; set; }

    public override bool IsValid(object? value)
    {
        var formFile = value as IFormFile;

        if (formFile == null)
            return true;

        if (Extenstion.Length != 0)
            return Extenstion.Any(x => formFile.ContentType.Contains(x.TrimStart('.')));

        return true;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context.Attributes.ContainsKey("data-val") == false)
        {
            context.Attributes.Add("data-val", "true");
        }

        string message = "Your file must have extensions";
        string values = "";
        foreach (var extenstion in Extenstion)
        {
            message += " - " + extenstion;
            values += $" {extenstion} ,";
        }

        values = values.TrimEnd(',').Trim();

        if (context.Attributes.ContainsKey("accept") == false)
        {
            context.Attributes.Add("accept", values);
        }


        context.Attributes.Add("data-val-extensions", ErrorMessage ?? message);
        
    }
}