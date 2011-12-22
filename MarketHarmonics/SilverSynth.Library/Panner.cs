// Panner.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

using System;
namespace SilverSynth.Library
{
    public class Panner : ISampleMaker, ISignalChainComponent
    {
        const double Floor = -80;

        int leftMultiplier = Constants.AttenuationConstant;
        int rightMultiplier = Constants.AttenuationConstant;
        double leftAttenuation;
        double rightAttenuation;
        short pan;

        public ISampleMaker Output { get; set; }
        public ISampleMaker Input { get; set; }

        public short Pan
        {
            get { return this.pan; }
            set
            {
                this.pan = value;

                if (this.pan > 0)
                {
                    // to the right, reduce left
                    this.LeftAttenuation = Panner.Floor * (double)this.pan / short.MaxValue;
                    this.RightAttenuation = 0;
                }
                else if (this.pan < 0)
                {
                    // to the left, reduce right
                    this.RightAttenuation = Panner.Floor * (double)this.pan / short.MinValue;
                    this.LeftAttenuation = 0;
                }
                else
                {
                    // in the center
                    this.LeftAttenuation = 0;
                    this.RightAttenuation = 0;
                }
            }
        }

        public StereoSample GetSample()
        {
            StereoSample sample = this.Input.GetSample();
            sample.LeftSample = this.Attenuate(sample.LeftSample, this.leftMultiplier);
            sample.RightSample = this.Attenuate(sample.RightSample, this.rightMultiplier);
            return sample;
        }

        double LeftAttenuation
        {
            set
            {
                this.leftAttenuation = value;
                leftMultiplier = (int)(Constants.AttenuationConstant * Math.Pow(10, this.leftAttenuation / 20.0));
            }
            get
            {
                return this.leftAttenuation;
            }
        }

        double RightAttenuation
        {
            set
            {
                this.rightAttenuation = value;
                rightMultiplier = (int)(Constants.AttenuationConstant * Math.Pow(10, this.rightAttenuation / 20.0));
            }
            get
            {
                return this.rightAttenuation;
            }
        }

        short Attenuate(short sample, int multiplier)
        {
            return (short)((sample * multiplier) >> 16);
        }


    }
}
