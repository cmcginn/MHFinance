// Envelope.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

namespace SilverSynth.Library
{
    public class Envelope
    {
        uint counter;
        uint attack;
        uint release;
        double attackSlope;
        double releaseSlope;
        uint releaseCounter;
        double rise;
        uint sustain;

        public Envelope()
        {
            this.Minimum = 0;
            this.Rise = 1;
            this.Attack = 0;
            this.Sustain = uint.MaxValue;
            this.Release = 0;
            this.Active = true;
        }

        public double Minimum { get; set; }
        public bool Releasing { get; protected set; }
        public bool Active { get; set; }

        public uint Sustain
        {
            get { return this.sustain; }
            set
            {
                this.sustain = value;
                this.UpdateReleaseSlope();
            }
        }

        public double Rise
        {
            get { return this.rise; }
            set
            {
                this.rise = value;
                this.UpdateAttackSlope();
                this.UpdateReleaseSlope();
            }
        }

        public uint Attack
        {
            get { return this.attack; }
            set
            {
                this.attack = value;
                this.UpdateAttackSlope();
                this.UpdateReleaseSlope();
            }
        }

        public uint Release
        {
            get { return this.release; }
            set
            {
                this.release = value;
                this.UpdateReleaseSlope();
            }
        }

        void UpdateAttackSlope()
        {
            this.attackSlope = this.Rise / (double)this.attack;
        }

        void UpdateReleaseSlope()
        {
            this.releaseSlope = -this.Rise / (double)
                ((this.release + this.Sustain + this.attack) - (this.attack + this.Sustain));
        }

        public void Reset()
        {
            counter = 0;
            this.releaseCounter = 0;
            this.Active = true;
            this.Releasing = false;
        }

        public double GetNextValue()
        {
            if (!this.Active)
            {
                return this.Rise + this.Minimum; //max value
            }

            if (this.Releasing)
            {
                this.releaseCounter++;
                return this.ProcessRelease();
            }
            else
            {
                counter++;

                if (counter < this.Attack)
                {
                    return this.ProcessAttack();
                }
                else
                {
                    if (counter == (this.attack + this.Sustain))
                        this.Releasing = true;
                    return this.Rise + this.Minimum;
                }
            }
        }

        double ProcessAttack()
        {
            //y = mx + b
            return (double)counter * this.attackSlope + Minimum;
        }

        double ProcessRelease()
        {
            //y = mx + b
            double result = (double)this.releaseCounter * this.releaseSlope + Minimum + Rise;
            return result > Minimum ? result : Minimum;
        }
    }
}
