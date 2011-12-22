// WaveTable.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com
// This in-memory wave table implementation was built with help 
// from Charles Petzold (www.charlespetzold.com)
	
using System;

namespace SilverSynth.Library
{
    public class WaveTable
    {
        static bool initialized;

        public static short[] SineWaveForm = new short[65536];
        public static double[] SineAmpModWaveForm = new double[65536];
        public static short[] SquareWaveForm = new short[65536];
        public static double[] SquareAmpModWaveForm = new double[65536];
        public static short[] SawWaveForm = new short[65536];
        public static double[] SawAmpModWaveForm = new double[65536];
        public static short[] TriangleWaveForm = new short[65536];
        public static double[] TriangleAmpModWaveForm = new double[65536];

        public static void InitializeWaveForms()
        {
            if (initialized)
                return;

            for (ushort i = 0; i < ushort.MaxValue; i++)
            {
                double ratio = (double)i / ushort.MaxValue;

                // oscillator arrays
                WaveTable.SineWaveForm[i] = (short)(short.MaxValue *
                        Math.Sin(2 * Math.PI / ushort.MaxValue * i));
                WaveTable.SawWaveForm[i] = (short)(short.MinValue + i);
                WaveTable.TriangleWaveForm[i] = (short)(i < (ushort.MaxValue) ? 1 * short.MinValue + 2 * i :
                                                                             3 * short.MaxValue - 2 * i);
                WaveTable.SquareWaveForm[i] = i < (ushort)short.MaxValue ? short.MinValue : short.MaxValue;

                // amp modulator arrays
                WaveTable.SineAmpModWaveForm[i] = (Math.Sin(2 * Math.PI * ratio) + 1) * .5000d;
                WaveTable.SawAmpModWaveForm[i] = ((-1 + (2 * ratio)) + 1) * .5000d;
                WaveTable.TriangleAmpModWaveForm[i] = ((i < (ushort.MaxValue) ? 1 * -1 + 2 * ratio :
                                                             3 * 1 - 2 * ratio) + 1) * .5000d;
                WaveTable.SquareAmpModWaveForm[i] = ((i < (double)short.MaxValue ? (double)-1 : (double)1) + 1) * .5000d;
            }

            // last oscillator slots
            WaveTable.SineWaveForm[65535] = (short)(short.MaxValue *
                Math.Sin(2 * Math.PI));
            WaveTable.SquareWaveForm[65535] = short.MaxValue;
            WaveTable.TriangleWaveForm[65535] = TriangleWaveForm[65534];  //hack
            WaveTable.SawWaveForm[65535] = (short)(short.MinValue + ushort.MaxValue);

            // last amp modulator slots
            WaveTable.SineAmpModWaveForm[65535] = 0;
            WaveTable.SawAmpModWaveForm[65535] = 1;
            WaveTable.TriangleAmpModWaveForm[65535] = WaveTable.TriangleAmpModWaveForm[65534]; //hack
            WaveTable.SquareAmpModWaveForm[65535] = 1;

            initialized = true;
        }
    }
}
