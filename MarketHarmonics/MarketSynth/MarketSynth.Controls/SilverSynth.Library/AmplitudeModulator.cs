// AmplitudeModulator.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

using System;
namespace SilverSynth.Library
{
    public class AmplitudeModulator
    {
        double modulationFrequency;
        uint increment;
        uint phaseAngle;

        public AmplitudeModulator()
        {
            this.Waveform = WaveForm.Sine;
            this.ModulationFrequency = 0;
            this.Envelope = new Envelope()
            {
                Attack = 0,
                Sustain = uint.MaxValue,
                Release = uint.MaxValue,
                Minimum = 0,
                Rise = 1, 
                Active = false
            };
        }

        public Envelope Envelope
        {
            get;
            set;
        }

        protected WaveForm Waveform { get; set; }

        public double ModulationFrequency
        {
            set
            {
                modulationFrequency = value;
                increment = (uint)(modulationFrequency * uint.MaxValue / Constants.SampleRate);
            }
            get { return modulationFrequency; }
        }

        public double GetNextAmplitude()
        {
            if (this.ModulationFrequency == 0)
                return 0;

            ushort shortPhaseAngle = (ushort)(phaseAngle >> 16);
            double result = 1;
            switch (this.Waveform)
            {
                case WaveForm.Sine:
                    result = WaveTable.SineAmpModWaveForm[shortPhaseAngle];
                    break;
                case WaveForm.Saw:
                    result = WaveTable.SawAmpModWaveForm[shortPhaseAngle];
                    break;
                case WaveForm.Square:
                    result = WaveTable.SquareAmpModWaveForm[shortPhaseAngle];
                    break;
                case WaveForm.Triangle:
                    result = WaveTable.TriangleAmpModWaveForm[shortPhaseAngle];
                    break;
            }
            double env = this.Envelope.GetNextValue();
            double newResult = result * env;
            phaseAngle += increment;
            return newResult;
        }

        public void Reset()
        {
            this.Envelope.Reset();
        }

    }
}
