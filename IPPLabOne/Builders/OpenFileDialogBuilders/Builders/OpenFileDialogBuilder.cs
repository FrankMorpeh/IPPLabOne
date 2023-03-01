using Microsoft.Win32;

namespace IPPLabOne.Builders.OpenFileDialogBuilders
{
    public abstract class OpenFileDialogBuilder
    {
        private OpenFileDialog itsOpenFileDialog;

        public void CreateOpenFileDialog()
        {
            itsOpenFileDialog = new OpenFileDialog();
        }

        public void SetTitle()
        {
            itsOpenFileDialog.Title = GetTitle();
        }
        protected abstract string GetTitle();

        public void SetExtension()
        {
            itsOpenFileDialog.DefaultExt = GetExtension();
        }
        protected abstract string GetExtension();

        public void SetAutomaticExtensionAdder()
        {
            itsOpenFileDialog.AddExtension = GetAddExtensionStatus();
        }
        protected abstract bool GetAddExtensionStatus();

        public void SetInitialDirectory()
        {
            itsOpenFileDialog.InitialDirectory = GetInitialDirectory();
        }
        protected abstract string GetInitialDirectory();

        public void SetFilter()
        {
            itsOpenFileDialog.Filter = GetFilter();
        }
        protected abstract string GetFilter();

        public OpenFileDialog BuildOpenFileDialog()
        {
            return itsOpenFileDialog;
        }
    }
}