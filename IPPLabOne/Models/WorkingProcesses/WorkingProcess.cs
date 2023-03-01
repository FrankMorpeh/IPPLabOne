using IPPLabOne.Converters.ThreadConverters;
using IPPLabOne.Converters.TimeConverters;
using IPPLabOne.ViewModels.WorkingProcessViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;

namespace IPPLabOne.Models.WorkingProcesses
{
    public class WorkingProcess : INotifyPropertyChanged
    {
        private Process itsProcess;
        private Timer itsTimer;
        private int itsTimeLeft;
        private string itsPathToProcess;
        private int itsWorkingTimeInSeconds;
        private event Action<WorkingProcess> itsProcessFinishedEvent;

        public int ProcessId { get { return itsProcess.Id; } }
        public string ProcessName { get { return itsProcess.ProcessName; } }
        public ProcessPriorityClass PriorityClass
        {
            get { return itsProcess.PriorityClass; }
            set { itsProcess.PriorityClass = value; OnPropertyChanged("PriorityClass"); }
        }
        public string ThreadsId { get { return ThreadsIdConverter.ThreadsIdToString(itsProcess.Threads); } }
        public int TimeLeft { get { return itsTimeLeft; } set { itsTimeLeft = value; OnPropertyChanged("TimeLeft"); } }
        public string PathToProcess { get { return itsPathToProcess; } set { itsPathToProcess = value; InitProcess(value); } }
        public int WorkingTimeInSeconds
        { 
            get { return itsWorkingTimeInSeconds; } 
            set { itsWorkingTimeInSeconds = value; TimeLeft = value; InitTimer(value); } 
        }
        public event Action<WorkingProcess> ProcessFinishedEvent 
        { 
            add { itsProcessFinishedEvent += value; } 
            remove { itsProcessFinishedEvent -= value; } 
        }

        public WorkingProcess()
        {
            itsProcess = null;
            itsTimer = null;
            itsTimeLeft = 0;
            itsPathToProcess = string.Empty;
            itsWorkingTimeInSeconds = 0;
            itsProcessFinishedEvent = null;
        }
        public WorkingProcess(string pathToProcess, int workingTimeInSeconds, WorkingProcessViewModel workingProcessViewModel)
        {
            InitProcess(pathToProcess);
            InitTimer(workingTimeInSeconds);
            TimeLeft = workingTimeInSeconds;
            itsPathToProcess = pathToProcess;
            itsWorkingTimeInSeconds = workingTimeInSeconds;
            itsProcessFinishedEvent += workingProcessViewModel.RemoveProcess;
        }
        private void InitProcess(string pathToProcess)
        {
            itsProcess = new Process();
            itsProcess.StartInfo.FileName = pathToProcess;
        }
        private void InitTimer(int workingTimeInSeconds)
        {
            itsTimer = new Timer(TimeConverter.ToMilliseconds(workingTimeInSeconds));
            itsTimer.Interval = 1000;
            itsTimer.Elapsed += OnTimedEvent;
        }

        public void StartProcess()
        {
            itsProcess.Start();
            itsTimer.Start();
        }


        // Timer event handlers
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            TimeLeft--;
            if (TimeLeft == 0)
            {
                itsProcess.CloseMainWindow();
                itsProcessFinishedEvent(this);
            }
        }


        // MVVM events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}