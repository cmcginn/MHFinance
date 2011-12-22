// ISignalChainComponent.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

using System;
namespace SilverSynth.Library
{
    public interface ISignalChainComponent : ISampleMaker
    {
        ISampleMaker Input { get; set; }
        ISampleMaker Output { get; set; }
    }
}
