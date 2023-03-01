using IPPLabOne.Models.WorkingProcesses;
using System;

namespace IPPLabOne.FluentBuilders.WorkingProcessFluentBuilders
{
    public class WorkingProcessFluentBuilder
    {
        private WorkingProcess itsWorkingProcess;

        public WorkingProcessFluentBuilder()
        {
            itsWorkingProcess = new WorkingProcess();
        }
        public WorkingProcessFluentBuilder SetPathToProcess(string pathToProcess)
        {
            itsWorkingProcess.PathToProcess = pathToProcess;
            return this;
        }
        public string GetPathToProcess() { return itsWorkingProcess.PathToProcess; }
        public WorkingProcessFluentBuilder SetWorkingTimeInSeconds(int? workingTimeInSeconds)
        {
            itsWorkingProcess.WorkingTimeInSeconds = workingTimeInSeconds ?? 0;
            return this;
        }
        public int GetWorkingTimeInSeconds() { return itsWorkingProcess.WorkingTimeInSeconds; }
        public WorkingProcessFluentBuilder SetProcessFinishedEventHandler(Action<WorkingProcess> processFinishedEventHandler)
        {
            itsWorkingProcess.ProcessFinishedEvent += processFinishedEventHandler;
            return this;
        }
        public WorkingProcess BuildWorkingProcess()
        {
            return itsWorkingProcess;
        }
    }
}