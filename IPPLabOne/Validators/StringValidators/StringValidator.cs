using System.Linq;

namespace IPPLabOne.Validators.StringValidators
{
    public static class StringValidator
    {
        public static bool StringIsEmpty(string str)
        {
            if (str != string.Empty && str.Any(s => char.IsLetterOrDigit(s)))
                return false;
            else
                return true;
        }
    }
}