using Microsoft.Win32;

namespace IPPLabOne.Builders.OpenFileDialogBuilders
{
    public static class OpenFileDialogManufacturer
    {
        public static OpenFileDialog BuildOpenFileDialog(OpenFileDialogBuilder openFileDialogBuilder)
        {
            openFileDialogBuilder.CreateOpenFileDialog();
            openFileDialogBuilder.SetTitle();
            openFileDialogBuilder.SetExtension();
            openFileDialogBuilder.SetAutomaticExtensionAdder();
            openFileDialogBuilder.SetInitialDirectory();
            openFileDialogBuilder.SetFilter();
            return openFileDialogBuilder.BuildOpenFileDialog();
        }
    }
}