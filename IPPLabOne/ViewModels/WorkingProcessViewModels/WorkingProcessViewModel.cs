using IPPLabOne.Models.WorkingProcesses;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IPPLabOne.ViewModels.WorkingProcessViewModels
{
    public class WorkingProcessViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<WorkingProcess> itsWorkingProcesses;

        public WorkingProcessViewModel()
        {
            itsWorkingProcesses = new ObservableCollection<WorkingProcess>();
        }

        public ObservableCollection<WorkingProcess> WorkingProcesses 
        { 
            get { return itsWorkingProcesses; }
            set { itsWorkingProcesses = value; OnPropertyChanged("WorkingProcesses"); }
        }

        public void AddProcess(WorkingProcess workingProcess)
        {
            itsWorkingProcesses.Add(workingProcess);
            itsWorkingProcesses[itsWorkingProcesses.Count - 1].StartProcess();
        }
        public void RemoveProcess(WorkingProcess workingProcess)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                itsWorkingProcesses.Remove(workingProcess);
            });
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