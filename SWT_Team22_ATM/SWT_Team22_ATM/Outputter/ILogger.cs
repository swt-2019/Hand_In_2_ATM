using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface ILogger
    {
        string PathToFile { get; set; }
        void LogCondition(ITrack track1, ITrack track2);
    }
}