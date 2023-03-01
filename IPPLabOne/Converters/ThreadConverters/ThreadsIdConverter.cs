using System;
using System.Diagnostics;

namespace IPPLabOne.Converters.ThreadConverters
{
    public static class ThreadsIdConverter
    {
        public static string ThreadsIdToString(ProcessThreadCollection processThreadCollection)
        {
            string threadsId = string.Empty;
            for (int i = 0; i < processThreadCollection.Count; i++)
            {
                threadsId += Convert.ToString(processThreadCollection[i].Id);
                if (i + 1 < processThreadCollection.Count)
                    threadsId += ", ";
            }
            return threadsId;
        }
    }
}