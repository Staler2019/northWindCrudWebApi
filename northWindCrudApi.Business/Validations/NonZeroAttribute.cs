namespace northWindCrudApi.Business.Validations;

using System.ComponentModel.DataAnnotations;

/**
 * @for int, long
 * @desc non-zero validation attribute
 */
public class NonZeroAttribute : ValidationAttribute
{
    private new const string ErrorMessageString = "{0} cannot be zero.";

    public override bool IsValid(object? value)
    {
        if (value is int intValue && intValue == 0)
        {
            return false;
        }

        if (value is long longValue && longValue == 0)
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
