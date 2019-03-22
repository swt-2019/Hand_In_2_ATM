namespace SWT_Team22_ATM.Domains
{
    public interface ITrack
    {
        Position TrackPosition { get; set; }
        string Tag { get; set; }

        string TimeStamp { get; set; }
        double Speed { get; set; }
        int Course { get; set; }
    }
}