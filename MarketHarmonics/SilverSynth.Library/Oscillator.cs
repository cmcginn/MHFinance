// Oscillator.cs adapted from
// http://www.charlespetzold.com/blog/2009/07/Simple-Electronic-Music-Sequencer-for-Silverlight.html
	
using System.Windows;
namespace SilverSynth.Library
{
    public class Oscillator : AttenuatorBase, ISignalChainComponent
    {
        uint increment;
        uint phaseAngle;
        double frequency;

        public Oscillator()
        {
            this.WaveFormType = WaveForm.Sine;
            this.FrequencyModulator = new FrequencyModulator();
            this.AmplitudeModulator = new AmplitudeModulator();
            this.Envelope = new Envelope()
            {
                Minimum = -80,
                Rise = 80
            };
        }

        public Envelope Envelope { get; set; }
        public ISampleMaker Output { get; set; }
        public WaveForm WaveFormType { get; set; }
        public FrequencyModulator FrequencyModulator { get; set; }
        public AmplitudeModulator AmplitudeModulator { get; set; }

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

        public override StereoSample GetSample()
        {
            ushort shortPhaseAngle = (ushort)(phaseAngle >> 16);
            short sample = 0;

            switch (this.WaveFormType)
            {
                case WaveForm.Sine:
                    sample = WaveTable.SineWaveForm[shortPhaseAngle];
                    break;

                case WaveForm.Square:
                    sample = WaveTable.SquareWaveForm[shortPhaseAngle];
                    break;

                case WaveForm.Triangle:
                    sample = WaveTable.TriangleWaveForm[shortPhaseAngle];
                    break;

                case WaveForm.Saw:
                    sample = WaveTable.SawWaveForm[shortPhaseAngle];
                    break;
            }

            int next = 0;
            if (this.FrequencyModulator != null)
            {
                next = this.FrequencyModulator.GetNextPhaseAngle();
            }
            phaseAngle += (uint)(increment + next);

            if (this.AmplitudeModulator != null)
            {
                // There is a performance improvement opportunity here.
                // The floating point math could be eliminated.

                double amp = this.AmplitudeModulator.GetNextAmplitude();
                sample = (short)(sample - (sample* amp));
            }

            double env = this.Envelope.GetNextValue();
            this.Attenuation = env;
            sample = this.Attenuate(sample);

            return new StereoSample() { LeftSample = sample, RightSample = sample };
        }

        public static Oscillator Create()
        {
            return new Oscillator();
        }

        public static Oscillator Create(double frequency)
        {
            return new Oscillator() { Frequency = frequency };
        }

        public static Oscillator Create(double frequency, WaveForm waveForm)
        {
            return new Oscillator() { Frequency = frequency, WaveFormType=waveForm };
        }

    }
}
