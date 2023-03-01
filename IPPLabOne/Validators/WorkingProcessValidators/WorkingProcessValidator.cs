using SharpLabFour.Notification;
using System.Collections.Generic;
using System.IO;

namespace IPPLabOne.Validators.WorkingProcessValidators
{
    public static class WorkingProcessValidator
    {
        public static List<INotification> CheckWorkingProcess(string pathToFile, int? workingTimeInSeconds)
        {
            List<INotification> warnings = new List<INotification>();
            if (StringValidators.StringValidator.StringIsEmpty(pathToFile) || !File.Exists(pathToFile))
                warnings.Add(new PathToFileIsIncorrect());
            if (workingTimeInSeconds == null || workingTimeInSeconds < 1)
                warnings.Add(new IncorrectWorkingTime());
            return warnings;
        }
    }
}