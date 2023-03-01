
namespace SharpLabFour.Notification
{
    public class PathToFileIsIncorrect : INotification
    {
        public string Text { get; set; }

        public PathToFileIsIncorrect() { Text = "PATH TO FILE IS INCORRECT!"; }
    }
    public class IncorrectWorkingTime : INotification
    {
        public string Text { get; set; }

        public IncorrectWorkingTime() { Text = "WORKING TIME MUST BE AT LEAST ONE SECOND!"; }
    }
    public class None : INotification
    {
        public string Text { get; set; }

        public None() { Text = "NONE"; }
    }
}