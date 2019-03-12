using System.Collections.Generic;
using TransponderReceiver;

namespace TransponderReceiverUser
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        public List<string> TransponderData { get; set; }

        protected void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            TransponderData = e.TransponderData;
        }
    }
}
