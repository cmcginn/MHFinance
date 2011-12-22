// StereoPcmStreamSource.cs adapted from 
// http://www.charlespetzold.com/blog/2009/07/Simple-Electronic-Music-Sequencer-for-Silverlight.html
	

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace SilverSynth.Library
{
    public class StereoPcmStreamSource : MediaStreamSource
    {
        MediaStreamDescription mediaStreamDescription;
        long startPosition;
        long currentPosition;
        long currentTimeStamp;
        int byteRate;
        short blockAlign;
        MemoryStream memoryStream;
        Dictionary<MediaSampleAttributeKeys, string> emptySampleDict =
            new Dictionary<MediaSampleAttributeKeys, string>();
        int bufferByteCount;
        const int numSamples = 512;

        public StereoPcmStreamSource()
        {
            WaveTable.InitializeWaveForms();
            byteRate = Constants.SampleRate * Constants.ChannelCount * Constants.BitsPerSample / 8;
            blockAlign = (short)(Constants.ChannelCount * (Constants.BitsPerSample / 8));
            memoryStream = new MemoryStream();
            bufferByteCount = Constants.ChannelCount *
                Constants.BitsPerSample / 8 * numSamples;
            this.BufferLength = 600;
        }

        public int BufferLength
        {
            get { return this.AudioBufferLength; }
            set { this.AudioBufferLength = value; }
        }

        public ISampleMaker Input
        {
            get;
            set;
        }

        protected override void OpenMediaAsync()
        {
            startPosition = currentPosition = 0;

            Dictionary<MediaStreamAttributeKeys, string> streamAttributes = new Dictionary<MediaStreamAttributeKeys, string>();
            Dictionary<MediaSourceAttributesKeys, string> sourceAttributes = new Dictionary<MediaSourceAttributesKeys, string>();
            List<MediaStreamDescription> availableStreams = new List<MediaStreamDescription>();

            string format = "";
            format += ToLittleEndianString(string.Format("{0:X4}", 1));  //PCM
            format += ToLittleEndianString(string.Format("{0:X4}", Constants.ChannelCount));
            format += ToLittleEndianString(string.Format("{0:X8}", Constants.SampleRate));
            format += ToLittleEndianString(string.Format("{0:X8}", byteRate));
            format += ToLittleEndianString(string.Format("{0:X4}", blockAlign));
            format += ToLittleEndianString(string.Format("{0:X4}", Constants.BitsPerSample));
            format += ToLittleEndianString(string.Format("{0:X4}", 0));

            streamAttributes[MediaStreamAttributeKeys.CodecPrivateData] = format;
            mediaStreamDescription = new MediaStreamDescription(MediaStreamType.Audio, streamAttributes);
            availableStreams.Add(mediaStreamDescription);
            sourceAttributes[MediaSourceAttributesKeys.Duration] = "0";
            sourceAttributes[MediaSourceAttributesKeys.CanSeek] = "false";
            ReportOpenMediaCompleted(sourceAttributes, availableStreams);
        }

        protected override void GetSampleAsync(MediaStreamType mediaStreamType)
        {
            for (int i = 0; i < numSamples; i++)
            {
                StereoSample sample;
                if (this.Input != null)
                    sample = this.Input.GetSample();
                else
                    sample = new StereoSample();

                //left channel
                memoryStream.WriteByte(
                    (byte)(sample.LeftSample & 0xFF));
                memoryStream.WriteByte(
                    (byte)(sample.LeftSample >> 8));


                //right channel
                memoryStream.WriteByte(
                        (byte)(sample.RightSample & 0xFF));
                memoryStream.WriteByte(
                        (byte)(sample.RightSample >> 8));

            }

            MediaStreamSample mediaStreamSample =
                new MediaStreamSample(mediaStreamDescription, memoryStream, currentPosition,
                                      bufferByteCount, currentTimeStamp, emptySampleDict);

            currentTimeStamp += bufferByteCount * 10000000L / byteRate;
            currentPosition += bufferByteCount;

            ReportGetSampleCompleted(mediaStreamSample);
        }

        protected override void SeekAsync(long seekToTime)
        {
            this.ReportSeekCompleted(seekToTime);
        }

        protected override void CloseMedia()
        {
            startPosition = currentPosition = 0;
            mediaStreamDescription = null;
        }

        protected override void GetDiagnosticAsync(MediaStreamSourceDiagnosticKind diagnosticKind)
        {
            throw new NotImplementedException();
        }

        protected override void SwitchMediaStreamAsync(MediaStreamDescription mediaStreamDescription)
        {
            throw new NotImplementedException();
        }

        string ToLittleEndianString(string bigEndianString)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bigEndianString.Length; i += 2)
                builder.Insert(0, bigEndianString.Substring(i, 2));

            return builder.ToString();
        }


    }
}
