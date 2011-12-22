using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverSynth.Library
{
    public class FastOscillator : ISampleMaker
    {
        uint increment;
        uint phaseAngle;
        double frequency;

        public FastOscillator()
        {
            this.WaveFormType = WaveForm.Sine;
            this.FrequencyModulator = new FastFrequencyModulator();
        }

        public WaveForm WaveFormType { get; set; }
        public FastFrequencyModulator FrequencyModulator { get; set; }

        public double Frequency
        {
            set
            {
                this.frequency = value;
                increment = (uint)(this.frequency * uint.MaxValue / Constants.SampleRate);
            }
            get
            {
                return this.frequency;
            }
        }

        public StereoSample GetSample()
        {
            ushort shortPhaseAngle = (ushort)(phaseAngle >> 16);
            short sample = 0;

            sample = WaveTable.SineWaveForm[shortPhaseAngle];

            int next = 0;
            if (this.FrequencyModulator != null)
            {
                next = this.FrequencyModulator.GetNextPhaseAngle();
            }
            phaseAngle += (uint)(increment + next);

           
          

            return new StereoSample() { LeftSample = sample, RightSample = sample };
        }

        public static Oscillator Create(double frequency)
        {
            return new Oscillator() { Frequency = frequency };
        }

        public static Oscillator Create(double frequency, WaveForm waveForm)
        {
            return new Oscillator() { Frequency = frequency, WaveFormType = waveForm };
        }

    }
}
