// Mixer.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com
	
using System.Collections.Generic;

namespace SilverSynth.Library
{
    public class Mixer : ISampleMaker
    {
        public Mixer()
        {
            this.Inputs = new List<ISignalChainComponent>();
        }

        public List<ISignalChainComponent> Inputs { get; protected set; }
        public bool EnableLimiting { get; set; }

        public StereoSample GetSample()
        {
            StereoSample newSample = new StereoSample();
            for (int i = 0; i < this.Inputs.Count; i++)
            {
                StereoSample sample = this.Inputs[i].GetSample();
                if (this.EnableLimiting && (int)(newSample.LeftSample + sample.LeftSample) > short.MaxValue)
                {
                    newSample.LeftSample = short.MaxValue;
                }
                else
                {
                    newSample.LeftSample += sample.LeftSample;
                }

                if (this.EnableLimiting && (int)(newSample.RightSample + sample.RightSample) > short.MaxValue)
                {
                    newSample.RightSample = short.MaxValue;
                }
                else
                {
                    newSample.RightSample += sample.RightSample;
                }
            }

            return newSample;
        }

        public void Remove(ISignalChainComponent component)
        {
            if (this.Inputs.Contains(component))
            {
                this.Inputs.Remove(component);
            }
        }

        public void RemoveAll()
        {
            this.Inputs.Clear();
        }

    }
}
