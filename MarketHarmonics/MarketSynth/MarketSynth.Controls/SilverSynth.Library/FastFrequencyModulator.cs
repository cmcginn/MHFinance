
using System;
namespace SilverSynth.Library
{
    public class FastFrequencyModulator
    {
        protected double modulationFrequency;
        protected uint increment;
        protected uint phaseAngle;
        const Int32 Scale = 65536;
        Int32 amplitudeFactor;
        short amplitude;

        public FastFrequencyModulator()
        {
            this.WaveForm = WaveForm.Sine;
            this.Amplitude = 0;
            this.ModulationFrequency = 0;

        }


        public short Amplitude {
            get
            {
                return this.amplitude;
            }
            set
            {
                //if (value < 0 || value > 1.000d)
                //    throw new ArgumentOutOfRangeException();

                this.amplitude = value;
                //this.amplitudeFactor = (Int32)(amplitude * Scale);
            }
        }
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

        public Int32 GetNextPhaseAngle()
        {
            ushort shortPhaseAngle = (ushort)(phaseAngle >> 16);
            int result = 0;
            result = (int)(this.Amplitude * WaveTable.SineWaveForm[shortPhaseAngle]);
            phaseAngle += increment;
            return result;
        }



    }
}
