using System.ComponentModel.DataAnnotations;

namespace northWindCrudApi.Business.Validations;

/**
 * @for string, ICollection<T>
 * @desc non-empty validation attribute
 */
public class NonEmptyAttribute : ValidationAttribute
{
    private new const string ErrorMessageString = "{0} cannot be empty.";

    public override bool IsValid(object? value)
    {
        if (value is string strValue && string.IsNullOrWhiteSpace(strValue))
        {
            return false;
        }

        if (value is ICollection<object> collection && collection.Count == 0)
        {
            return false;
        }

        return true;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name);
    }
}
