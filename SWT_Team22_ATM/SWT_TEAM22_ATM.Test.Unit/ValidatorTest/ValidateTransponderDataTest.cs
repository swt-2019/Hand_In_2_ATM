using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Smtp;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Validation;
using SWT_TEAM22_ATM.Test.Unit.TestMonitors;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class ValidateTransponderDataTest
    {
        //the event fired by the TransponderDataInterpreter
        //private EventHandler<TrackListEventArgs> _uutEventHandler;

        private ITrackListEvent _trackListEvent;

        private ValidateTransponderData _validateTransponderData;

        // stores the validated data, when validation is complete
        private ValidateEventArgs _validationCompleteEventArgs;


        //Utility
        private ITrackable _airspace;

        [SetUp]
        public void TestSetUp()
        {
           _validationCompleteEventArgs = null;

           _trackListEvent = Substitute.For<ITrackListEvent>();

             // setup Airspace to work on
             _airspace = FakeAirspaceGenerator.GetAirspace(50, 100, 150);

            // set Validator to subscribe to Interpreter(done in constructor)
            _validateTransponderData = new ValidateTransponderData(ref _trackListEvent, _airspace);

            // setup listener
            _validateTransponderData.ValidationCompleteEventHandler += (sender, args) => { _validationCompleteEventArgs = args; };
        }

        [Test]
        public void ValidateTransponderData_EventHandlerInvoked()
        {
            var invoked = false;
            var tracksWithTags = FakeTrackFactory.GetMultipleTracksWithTags(10);

            //This is the shared eventargs between Interpreter and Validator
            var trackListEventArgs = new TrackListEventArgs (tracksWithTags);

            _trackListEvent.TrackListEventHandler += (sender, args) => invoked = true;

            // by invoke, all "subscribers" are notified - in this case it is the ValidateTransponderData
            _trackListEvent.TrackListEventHandler += Raise.EventWith(new object(), trackListEventArgs);

            Assert.That(invoked);    
        }


        [Test]
        public void OnNewValidation_ValidateTracksReceived_NewInAirspace_EventHandlerInvoked()// airspace starts empty
        {
            var tracksWithTags = FakeTrackFactory.GetMultipleTracksWithTags(10);

            //This is the shared eventargs between Interpreter and Validator
            var trackListEventArgs = new TrackListEventArgs(tracksWithTags);

            // by invoke, all "subscribers" are notified - in this case it is the ValidateTransponderData
            _trackListEvent.TrackListEventHandler += Raise.EventWith(new object(), trackListEventArgs);


            CollectionAssert.AreEqual(tracksWithTags, _validationCompleteEventArgs.NewInAirspace);
        }


        [Test]
        public void OnNewValidation_ValidateTracks_TrackAlreadyRegistered_EventHandlerInvoked()
        {
            var track1 = FakeTrackFactory.GetTrackWithTag("BCD123", 200, 300, 400);

            // pre-adds track to Airspace
            _validateTransponderData.Airspace.Trackables.Add(track1);

            // adds the same track to a list
            var tracksWithTags = new List<ITrack>(){ track1};

            //This is the shared eventargs between Interpreter and Validator - now the TrackListEventArgs trackList also contains the same track
            var trackListEventArgs = new TrackListEventArgs(tracksWithTags);

            // by invoke, all "subscribers" are notified - in this case it is the ValidateTransponderData
            _trackListEvent.TrackListEventHandler += Raise.EventWith(new object(), trackListEventArgs);

            Assert.Contains(track1, _validationCompleteEventArgs.StillInAirspace);
        }

        [Test]
        public void OnNewValidation_ValidateTracks_NotInAirspaceAnymore_EventHandlerInvoked()
        {
            var track1 = FakeTrackFactory.GetTrackWithTag("BCD123", 200, 300, 400);

            // pre-adds track to Airspace
            _validateTransponderData.Airspace.Trackables.Add(track1);

            // these coordinates are not in airspace
            track1.TrackPosition.XCoordinate = 10;
            track1.TrackPosition.YCoordinate = 20;
            track1.TrackPosition.ZCoordinate = 30;

            // adds the same track with updated coordinates to a list
            var tracksWithTags = new List<ITrack>() { track1 };

            //This is the shared eventargs between Interpreter and Validator - now the TrackListEventArgs trackList also contains the same track
            var trackListEventArgs = new TrackListEventArgs(tracksWithTags);

            // by invoke, all "subscribers" are notified - in this case it is the ValidateTransponderData
            _trackListEvent.TrackListEventHandler += Raise.EventWith(new object(), trackListEventArgs);

            /*_validationCompleteEventArgs.NotInAirspaceButUsedToBe.ForEach(track => Console.WriteLine(track.Tag + " " + 
                                                                                                     track.TrackPosition.XCoordinate + " " + 
                                                                                                     track.TrackPosition.YCoordinate + " " + 
                                                                                                     track.TrackPosition.ZCoordinate));*/

            /*_validationCompleteEventArgs.NotInAirspaceButUsedToBe.ForEach(track => Console.WriteLine(track.Tag));
            _validationCompleteEventArgs.NewInAirspace.ForEach(track => Console.WriteLine(track.Tag));
            _validationCompleteEventArgs.StillInAirspace.ForEach(track => Console.WriteLine(track.Tag));*/


            Assert.Contains(track1, _validationCompleteEventArgs.NotInAirspaceButUsedToBe);
        }

    }
}