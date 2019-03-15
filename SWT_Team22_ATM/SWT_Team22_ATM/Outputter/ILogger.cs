using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface ILogger
    {
        void LogCondition(ITrack track1, ITrack track2, string pathToFile);
    }
}