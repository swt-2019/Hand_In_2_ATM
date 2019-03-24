using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Validation;
using SWT_Team22_ATM.Updater;
using SWT_Team22_ATM.Updater.ICalculateTracks;
using TransponderReceiver;

namespace SWT_Team22_ATM_ConsoleApp
{
    class Program
    {
        static ITransponderReceiver tr;
        static TransponderDataInterpreter TDInterpreter;
        static ValidateTransponderData validator;
        static Airspace airspace;
        static AirspaceTrackConditionDetector airCondDetector;
        static AirTrafficMonitor Monitor;
        static AirTrafficOutputter AirOutputter;

        static void Main(string[] args)
        {
            setup();

            tr.TransponderDataReady += onTransponderDataReceived;
            while (true) { } ;
            
        }

        static void setup()
        {
            tr = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TDInterpreter = new TransponderDataInterpreter();
            TDInterpreter.subscribe(tr);

            Position p = new Position();
            p.XCoordinate = 30000;
            p.YCoordinate = 30000;
            p.ZCoordinate = 5;

            airspace = new Airspace();
            airspace.AirspacePosition = p;
            airspace.HorizontalSize = 100000;
            airspace.VerticalEnd = 100000;

            ITrackListEvent itlEvent = TDInterpreter;
            validator = new ValidateTransponderData(ref itlEvent , airspace);

            AirOutputter = new AirTrafficOutputter();
            AirOutputter.TrafficController = new ConsoleAirTrafficController();
            List<IConditionStrategy<ITrack>> conditionStrategies = new List<IConditionStrategy<ITrack>>();

            conditionStrategies.Add(new TrackAltitudeCondition() { AltitudeRestriction = 100000 });
            conditionStrategies.Add(new TrackHorizontalDistanceCondition() { HorizontalDistance = 100000 });

            airCondDetector = new AirspaceTrackConditionDetector(conditionStrategies);

            TrackHorizontalDistanceCalculator HorizontalDistanceCalc = new TrackHorizontalDistanceCalculator();
            TrackSpeedCalculator speedCalc = new TrackSpeedCalculator(HorizontalDistanceCalc);
            TrackCourseCalculator courseCalc = new TrackCourseCalculator();
            AirspaceUpdater airUpdater = new AirspaceUpdater(speedCalc,courseCalc);
            

            Monitor = new AirTrafficMonitor(validator, airCondDetector,AirOutputter,airUpdater);
            FileLogger fl = new FileLogger();
            fl.PathToFile = "../../log.txt";
            AirOutputter.Logger = fl;
        }

        static void onTransponderDataReceived(object sender, RawTransponderDataEventArgs e)
        {
            Console.WriteLine("Received:");
            foreach(var s in e.TransponderData)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n");
        }
    }


}
