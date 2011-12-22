// AttenuatorBase.cs adapted from
// http://www.charlespetzold.com/blog/2009/07/Simple-Electronic-Music-Sequencer-for-Silverlight.html

using System;

namespace SilverSynth.Library
{
    public class AttenuatorBase : ISampleMaker
    {
        double attenuation = -80;        // in db
        int attenuationMultiplier = Constants.AttenuationConstant;

        public ISampleMaker Input { get; set; }

        public double Attenuation
        {
            set
            {
                attenuation = value;
                attenuationMultiplier = (int)(Constants.AttenuationConstant * Math.Pow(10, attenuation / 20.0));
            }
            get
            {
                return attenuation;
            }
        }

        public virtual StereoSample GetSample()
        {
            StereoSample sample = this.Input.GetSample();
            sample.LeftSample = this.Attenuate(sample.LeftSample);
            sample.RightSample = this.Attenuate(sample.RightSample);
            return sample;
        }

        protected short Attenuate(short sample)
        {
            return (short)((sample * attenuationMultiplier) >> 16);
        }

    }
}
