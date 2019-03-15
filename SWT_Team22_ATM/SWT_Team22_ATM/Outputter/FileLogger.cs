using System;
using System.IO;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class FileLogger : ILogger
    {
        public void LogCondition(ITrack track1, ITrack track2, string pathToFile)
        {
            using (StreamWriter w = File.AppendText(pathToFile))
            {
                w.WriteLine("Condition detected between " + track1.Tag + " & " + track2.Tag);
                
                w.Close();
            }
        }
    }
}