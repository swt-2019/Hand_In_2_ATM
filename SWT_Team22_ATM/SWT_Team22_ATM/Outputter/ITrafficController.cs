using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface ITrafficController
    {
        void DisplayTracks(List<ITrack> trackables);
        void DisplayConditions(List<Condtion> condtions, List<ITrack> trackables);
    }
}