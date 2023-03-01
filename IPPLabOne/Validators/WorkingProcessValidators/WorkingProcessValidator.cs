using SharpLabFour.Notification;
using System.IO;

namespace IPPLabOne.Validators.WorkingProcessValidators
{
    public static class WorkingProcessValidator
    {
        public static INotification CheckWorkingProcess(string pathToFile)
        {
            if (StringValidators.StringValidator.StringIsEmpty(pathToFile) || !File.Exists(pathToFile))
                return new PathToFileIsIncorrect();
            else
                return new None();
        }
    }
}