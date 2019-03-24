using System;
using System.IO;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class FileLogger : ILogger
    {
        public string PathToFile { get; set; }
        public void LogCondition(ITrack track1, ITrack track2)
        {
            using (StreamWriter w = File.AppendText(PathToFile))
            {
                w.WriteLine("Condition detected between " + track1.Tag + " & " + track2.Tag);
                w.Close();
            }
        }
    }
}