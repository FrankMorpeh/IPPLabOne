
namespace SharpLabFour.Notification
{
    public class PathToFileIsIncorrect : INotification
    {
        public string Text { get; set; }

        public PathToFileIsIncorrect() { Text = "PATH TO FILE IS INCORRECT!"; }
    }
    public class None : INotification
    {
        public string Text { get; set; }

        public None() { Text = "NONE"; }
    }
}