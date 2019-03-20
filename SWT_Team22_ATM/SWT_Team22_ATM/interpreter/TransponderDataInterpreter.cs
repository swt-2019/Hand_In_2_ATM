﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;
using TransponderReceiver;
namespace SWT_Team22_ATM.interpreter
{
   public class TransponderDataInterpreter : Iinterpret, TrackListEvent
    {
        public event EventHandler<TrackListEventArgs> TrackListEventHandler;

        public void subscribe(EventHandler<RawTransponderDataEventArgs> handler)
        {
            handler += interpret;
        }
        private void interpret(object sender, RawTransponderDataEventArgs e)
        {
            List<Track> Tracks = new List<Track>();
            foreach(var data in e.TransponderData)
            {
                Tracks.Add(interpret(data));
            }

        }

        private Track interpret(string TransponderData)
        {
            // ATR423;39045;12932;14000;20151006213456789 

            string[] s = TransponderData.Split(';');

            Track t = new Track();
            Position p = new Position();

            t.Tag = s[0];


            int x;
            int y;
            if (Int32.TryParse(s[1], out x))
            {
                p.XCoordinate = x;
            }

            if (Int32.TryParse(s[2], out y))
            {
                p.YCoordinate = y;
            }

            t.TrackPosition = p;

            int a;
            if (Int32.TryParse(s[3], out a))
            {
                t.TrackPosition.ZCoordinate = a;
            }

            t.TimeStamp = s[4];

            OnNewTag(new ValidateEventArgs()
            {
                Track = t
            });

            return t;

        }

        

        protected virtual void OnNewTag(ValidateEventArgs e)
        {
            TrackListEventHandler?.Invoke(this,e);
        }

    }
}
