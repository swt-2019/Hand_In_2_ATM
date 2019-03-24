using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Updater.ICalculateTracks
{
    public interface ITrackCalculator<TReturn>
    {
        TReturn Calculate(ITrack firstTrack, ITrack secondTrack);
    }
}