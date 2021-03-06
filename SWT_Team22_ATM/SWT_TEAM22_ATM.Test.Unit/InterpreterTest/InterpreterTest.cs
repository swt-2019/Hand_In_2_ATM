﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.interpreter;
using TransponderReceiver;
using NUnit.Framework;
using NSubstitute;

namespace SWT_TEAM22_ATM.Test.Unit.InterpreterTest
{
    public class InterpreterTest
    {
        //simulates the event fired by the Transponder
        public TransponderDataInterpreter _uut;
        //stores output from the event fired when interpret is done
        public TrackListEventArgs TrackListArgs;
        public ITransponderReceiver handler;

        [SetUp]
        public void setup()
        {
            TrackListArgs = null;
            _uut = new TransponderDataInterpreter();

            handler = Substitute.For<ITransponderReceiver>();
            //subscribe handler interpreter event
            _uut.subscribe(handler);
            

            //setup event listener
            _uut.TrackListEventHandler += (o, args) => { TrackListArgs = args; };

        }



        [TestCase("ATR423;39045;12932;14000;20151006213456789")]
        [TestCase("BCD123;10005;85890;12000;20151006213456789")]
        [TestCase("XYZ987;25059;75654;4000;20151006213456789")]
        public void testInterpretDataReceived(string s)
        {
            List<string> strings = new List<string>();
            strings.Add(s);
            
            RawTransponderDataEventArgs args = new RawTransponderDataEventArgs(strings);
            handler.TransponderDataReady += Raise.EventWith(this, args);

            //check that event listener is not null
            Assert.That(TrackListArgs,Is.Not.Null);
        }

        [TestCase("ATR423;39045;12932;14000;20151006213456789")]
        [TestCase("BCD123;10005;85890;12000;20151006213456789")]
        [TestCase("XYZ987;25059;75654;4000;20151006213456789")]
        public void testOutputInterpreter(string s)
        {
            List<string> strings = new List<string>();
            strings.Add(s);

            RawTransponderDataEventArgs args = new RawTransponderDataEventArgs(strings);
            handler.TransponderDataReady += Raise.EventWith(this, args);

            Assert.That(TrackListArgs.Tracks[0].Tag == s.Split(';')[0]);
        }

        [TestCase("ATR423;39045;12932;14000;20151006213456789,BCD123;10005;85890;12000;20151006213456789,XYZ987;25059;75654;4000;20151006213456789")]
        public void testOutplutOfListInterpreter(string s)
        {
            List<string> strings = new List<string>();

            foreach(string data in s.Split(','))
            {
                strings.Add(data);
            }
            RawTransponderDataEventArgs args = new RawTransponderDataEventArgs(strings);
            handler.TransponderDataReady += Raise.EventWith(this, args);

            List<string> stringsOut = new List<string>();
            foreach(var trackOut in TrackListArgs.Tracks)
            {
                stringsOut.Add(trackOut.Tag + ";" + trackOut.TrackPosition.XCoordinate + ";" + trackOut.TrackPosition.YCoordinate + ";" + trackOut.TrackPosition.ZCoordinate + ";" + trackOut.TimeStamp);
            }
            Assert.That(stringsOut.SequenceEqual(strings));
        }

    }
}
