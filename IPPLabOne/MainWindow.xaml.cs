using IPPLabOne.Builders.OpenFileDialogBuilders;
using IPPLabOne.FluentBuilders.WorkingProcessFluentBuilders;
using IPPLabOne.Validators.WorkingProcessValidators;
using IPPLabOne.ViewModels.WorkingProcessViewModels;
using Microsoft.Win32;
using SharpLabFour.Notification;
using System.Windows;

namespace IPPLabOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string initialLocation;
        public WorkingProcessViewModel workingProcessViewModel;
        public WorkingProcessFluentBuilder workingProcessFluentBuilder;

        static MainWindow()
        {
            initialLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            initialLocation = System.IO.Path.GetDirectoryName(initialLocation);
        }
        public MainWindow()
        {
            InitializeComponent();
            InitializeExtraComponents();

            workingProcessViewModel = new WorkingProcessViewModel();
            DataContext = workingProcessViewModel;
            workingProcessFluentBuilder = new WorkingProcessFluentBuilder();
        }
        private void InitializeExtraComponents()
        {
            processDurationIntegerUpDown.Minimum = 1;
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = OpenFileDialogManufacturer.BuildOpenFileDialog(new ExeOpenFileDialogBuilder());
            if (openFileDialog.ShowDialog() == true)
                workingProcessFluentBuilder.SetPathToProcess(openFileDialog.FileName);
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            INotification notification = WorkingProcessValidator.CheckWorkingProcess(workingProcessFluentBuilder.GetPathToProcess());
            if (notification is None)
            {
                workingProcessViewModel.AddProcess(workingProcessFluentBuilder.SetWorkingTimeInSeconds(processDurationIntegerUpDown.Value)
                    .SetProcessFinishedEventHandler(workingProcessViewModel.RemoveProcess).BuildWorkingProcess());
            }
            else
                NotificationView.ShowNotification(notificationStackPanel, notificationTextBlock, notification);
        }
    }
}