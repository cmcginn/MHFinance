// FrequencyModulator.cs (c) Copyright 2009, Mike Hodnick : www.kindohm.com
// Modulation code implemented with help from Charles Petzold (www.charlespetzold.com)

using System;
using System.Diagnostics;
namespace SilverSynth.Library
{
    public class FrequencyModulator
    {
        protected double modulationFrequency;
        protected uint increment;
        protected uint phaseAngle;

        public FrequencyModulator()
        {
            this.WaveForm = WaveForm.Sine;
            this.Amplitude = 0;
            this.ModulationFrequency = 0;
            this.Envelope = new Envelope()
            {
                Attack = 0,
                Sustain = 5000,
                Release = 5000,
                Minimum = 0,
                Rise = 1,
                Active=false
            };
        }

        public Envelope Envelope
        {
            get;
            set;
        }

        public short Amplitude { get; set; }
        public WaveForm WaveForm { get; set; }

        public double ModulationFrequency
        {
            set
            {
                modulationFrequency = value;
                increment = (uint)(modulationFrequency * uint.MaxValue / Constants.SampleRate);
            }
            get { return modulationFrequency; }
        }

        public int GetNextPhaseAngle()
        {
            ushort shortPhaseAngle = (ushort)(phaseAngle >> 16);
            int result = 0;
            double envelopeValue = this.Envelope.GetNextValue();

            switch (this.WaveForm)
            {
                case WaveForm.Sine:
                    result = (int)(this.Amplitude * envelopeValue * WaveTable.SineWaveForm[shortPhaseAngle]);
                    break;
                case WaveForm.Saw:
                    result = (int)(this.Amplitude * envelopeValue * WaveTable.SawWaveForm[shortPhaseAngle]);
                    break;
                case WaveForm.Square:
                    result = (int)(this.Amplitude * envelopeValue * WaveTable.SquareWaveForm[shortPhaseAngle]);
                    break;
                case WaveForm.Triangle:
                    result = (int)(this.Amplitude * envelopeValue * WaveTable.TriangleWaveForm[shortPhaseAngle]);
                    break;
            }

            phaseAngle += increment;
            return result;
        }

        public void Reset()
        {
            this.Envelope.Reset();
        }

    }
}
