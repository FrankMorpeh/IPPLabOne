using IPPLabOne.Builders.OpenFileDialogBuilders;
using IPPLabOne.FluentBuilders.WorkingProcessFluentBuilders;
using IPPLabOne.Validators.WorkingProcessValidators;
using IPPLabOne.ViewModels.WorkingProcessViewModels;
using Microsoft.Win32;
using SharpLabFour.Notification;
using System.Collections.Generic;
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
            processDurationIntegerUpDown.Value = 1;
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = OpenFileDialogManufacturer.BuildOpenFileDialog(new ExeOpenFileDialogBuilder());
            if (openFileDialog.ShowDialog() == true)
                workingProcessFluentBuilder.SetPathToProcess(openFileDialog.FileName);
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            List<INotification> warnings = WorkingProcessValidator.CheckWorkingProcess(workingProcessFluentBuilder.GetPathToProcess()
                , processDurationIntegerUpDown.Value);
            if (warnings.Count == 0)
            {
                workingProcessViewModel.AddProcess(workingProcessFluentBuilder.SetWorkingTimeInSeconds(processDurationIntegerUpDown.Value)
                    .SetProcessFinishedEventHandler(workingProcessViewModel.RemoveProcess).BuildWorkingProcess());
                workingProcessFluentBuilder = new WorkingProcessFluentBuilder();
            }
            else
                NotificationView.ShowNotifications(notificationStackPanel, notificationTextBlock, warnings);
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationView.HideNotifications(notificationStackPanel);
        }
    }
}