namespace IPPLabOne.Builders.OpenFileDialogBuilders
{
    public class ExeOpenFileDialogBuilder : OpenFileDialogBuilder
    {
        protected override string GetTitle()
        {
            return "Executable file";
        }
        protected override string GetExtension()
        {
            return "exe";
        }
        protected override bool GetAddExtensionStatus()
        {
            return true;
        }
        protected override string GetInitialDirectory()
        {
            return MainWindow.initialLocation;
        }
        protected override string GetFilter()
        {
            return "Executable files(*.exe)|*.exe";
        }
    }
}