﻿using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class ValidatorEventHandlerInvoked
    {
        private ValidateTransponderData _uutValidateTransponderData;
        private ITrackListEvent _trackListEvent;
        private ITrackable _airspace;
        private TrackListEventArgs _trackListEventArgs;

        [SetUp]
        public void TestSetup()
        {
            _trackListEvent = Substitute.For<ITrackListEvent>();
            _airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);

            _uutValidateTransponderData = new ValidateTransponderData(ref _trackListEvent, _airspace);
        }

        [Test]
        public void OnValidationComplete_Invoked()
        {
            var invoked = false;

            var trackList = FakeTrackFactory.GetMultipleTracksWithTags(1);
            _trackListEventArgs = new TrackListEventArgs(trackList);

            _uutValidateTransponderData.ValidationCompleteEventHandler += (sender, args) => invoked = true;

            _trackListEvent.TrackListEventHandler += Raise.EventWith(this, _trackListEventArgs);

            Assert.That(invoked);
        }
    }
}