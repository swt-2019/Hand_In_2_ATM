using System.Runtime.InteropServices;

namespace SWT_Team22_ATM.Updater
{
    public interface IUpdater<T>
    {
        void Update(ref T needsUpdate, T update);
    }
}