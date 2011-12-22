// Attenuator.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

using System;

namespace SilverSynth.Library
{
    public class Attenuator : AttenuatorBase, ISignalChainComponent
    {
        public ISampleMaker Output { get; set; }
    }
}
