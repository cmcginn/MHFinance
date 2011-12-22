// FluentAudio.cs (c) Copyright 2009, Mike Hodnick : www.hodnick.com

using System.Windows;
using System.Windows.Data;

namespace SilverSynth.Library
{
    public static class FluentAudio
    {

        public static Oscillator AmplitudeModulate(this Oscillator oscillator, double frequency)
        {
            oscillator.AmplitudeModulator.ModulationFrequency = frequency;
            return oscillator;
        }

        public static Oscillator AmplitudeModulate(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Binding frequencyBinding = new Binding();
            frequencyBinding.Mode = BindingMode.TwoWay;
            frequencyBinding.Source = oscillator.AmplitudeModulator;
            frequencyBinding.Path = new PropertyPath("ModulationFrequency");
            target.SetBinding(property, frequencyBinding);
            return oscillator;
        }

        public static Attenuator Attenuate(this Oscillator oscillator, double attenuation)
        {
            Attenuator item = new Attenuator() { Attenuation = attenuation, Input = oscillator };
            oscillator.Output = item;
            return item;
        }

        public static Attenuator Attenuate(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Attenuator attenuator = new Attenuator();
            attenuator.Input = oscillator;
            oscillator.Output = attenuator;
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = attenuator;
            binding.Path = new PropertyPath("Attenuation");
            target.SetBinding(property, binding);
            return attenuator;
        }

        public static Attenuator Attenuate(this Panner panner, double attenuation)
        {
            Attenuator item = new Attenuator() { Attenuation = attenuation, Input = panner };
            panner.Output = item;
            return item;
        }

        public static Attenuator Attenuate(this Panner panner, FrameworkElement target, DependencyProperty property)
        {
            Attenuator attenuator = new Attenuator() { Input = panner, Attenuation = (double)target.GetValue(property) };
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = attenuator;
            binding.Path = new PropertyPath("Attenuation");
            target.SetBinding(property, binding);
            panner.Output = attenuator;
            return attenuator;
        }

        public static Attenuator Attenuate(this Mixer mixer, double attenuation)
        {
            return new Attenuator() { Attenuation = attenuation, Input = mixer };
        }

        public static Attenuator Attenuate(this Mixer mixer, FrameworkElement target, DependencyProperty property)
        {
            Attenuator attenuator = new Attenuator() { Input = mixer };
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = attenuator;
            binding.Path = new PropertyPath("Attenuation");
            target.SetBinding(property, binding);
            return attenuator;
        }

        public static Attenuator Attenuate(this Attenuator attenuator, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = attenuator;
            binding.Path = new PropertyPath("Attenuation");
            target.SetBinding(property, binding);
            return attenuator;
        }

        public static Oscillator FrequencyModulate(this Oscillator oscillator, double frequency, short amplitude)
        {
            oscillator.FrequencyModulator.ModulationFrequency = frequency;
            oscillator.FrequencyModulator.Amplitude = amplitude;
            return oscillator;
        }

        public static Oscillator FrequencyModulate(this Oscillator oscillator, double frequency, short amplitude, WaveForm waveForm)
        {
            oscillator.FrequencyModulator.ModulationFrequency = frequency;
            oscillator.FrequencyModulator.Amplitude = amplitude;
            oscillator.FrequencyModulator.WaveForm = waveForm;
            return oscillator;
        }

        public static Oscillator FrequencyModulateFrequency(this Oscillator oscillator, FrameworkElement frequencyTarget, DependencyProperty frequencyProperty)
        {
            return oscillator.FrequencyModulate(
                frequencyTarget, frequencyProperty, null, null, oscillator.FrequencyModulator.WaveForm);
        }

        public static Oscillator FrequencyModulateAmplitude(this Oscillator oscillator, FrameworkElement amplitudeTarget, DependencyProperty amplitudeProperty)
        {
            return oscillator.FrequencyModulate(
                null, null, amplitudeTarget, amplitudeProperty, oscillator.FrequencyModulator.WaveForm);
        }

        public static Oscillator FrequencyModulate(this Oscillator oscillator, FrameworkElement frequencyTarget, DependencyProperty frequencyProperty, FrameworkElement amplitudeTarget, DependencyProperty amplitudeProperty)
        {
            return oscillator.FrequencyModulate(
                frequencyTarget, frequencyProperty, amplitudeTarget, amplitudeProperty, oscillator.FrequencyModulator.WaveForm);
        }

        public static Oscillator FrequencyModulate(this Oscillator oscillator, FrameworkElement frequencyTarget, DependencyProperty frequencyProperty, FrameworkElement amplitudeTarget, DependencyProperty amplitudeProperty, WaveForm waveForm)
        {
            oscillator.FrequencyModulator.WaveForm = waveForm;

            if (frequencyProperty != null && frequencyTarget != null)
            {
                Binding frequencyBinding = new Binding();
                frequencyBinding.Mode = BindingMode.TwoWay;
                frequencyBinding.Source = oscillator.FrequencyModulator;
                frequencyBinding.Path = new PropertyPath("ModulationFrequency");
                frequencyTarget.SetBinding(frequencyProperty, frequencyBinding);
            }

            if (amplitudeProperty != null && amplitudeTarget != null)
            {
                Binding amplitudeBinding = new Binding();
                amplitudeBinding.Mode = BindingMode.TwoWay;
                amplitudeBinding.Source = oscillator.FrequencyModulator;
                amplitudeBinding.Path = new PropertyPath("Amplitude");
                amplitudeTarget.SetBinding(amplitudeProperty, amplitudeBinding);
            }

            return oscillator;
        }

        public static Panner Pan(this Oscillator oscillator, short pan)
        {
            Panner panner = new Panner() { Pan = pan, Input = oscillator };
            oscillator.Output = panner;
            return panner;
        }

        public static Panner Pan(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Panner panner = new Panner() { Input = oscillator };
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = panner;
            binding.Path = new PropertyPath("Pan");
            target.SetBinding(property, binding);
            oscillator.Output = panner;
            return panner;
        }

        public static Panner Pan(this Attenuator attenuator, short pan)
        {
            Panner panner = new Panner() { Pan = pan, Input = attenuator };
            attenuator.Output = panner;
            return panner;
        }

        public static Panner Pan(this Panner panner, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = panner;
            binding.Path = new PropertyPath("Pan");
            target.SetBinding(property, binding);
            return panner;
        }

        public static Oscillator SendToMixer(this Oscillator oscillator, Mixer mixer)
        {
            mixer.Inputs.Add(oscillator);
            oscillator.Output = mixer;
            return oscillator;
        }

        public static Mixer SendToMixer(this Oscillator oscillator)
        {
            Mixer mixer = new Mixer();
            mixer.Inputs.Add(oscillator);
            oscillator.Output = mixer;
            return mixer;
        }

        public static Attenuator SendToMixer(this Attenuator attenuator, Mixer mixer)
        {
            mixer.Inputs.Add(attenuator);
            attenuator.Output = mixer;
            return attenuator;
        }

        public static Mixer SendToMixer(this Attenuator attenuator)
        {
            Mixer mixer = new Mixer();
            mixer.Inputs.Add(attenuator);
            attenuator.Output = mixer;
            return mixer;
        }

        public static Panner SendToMixer(this Panner panner, Mixer mixer)
        {
            mixer.Inputs.Add(panner);
            panner.Output = mixer;
            return panner;
        }

        public static Mixer SendToMixer(this Panner panner)
        {
            Mixer mixer = new Mixer();
            mixer.Inputs.Add(panner);
            panner.Output = mixer;
            return mixer;
        }

        public static Envelope SetAttack(this Envelope envelope, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = envelope;
            binding.Path = new PropertyPath("Attack");
            target.SetBinding(property, binding);
            return envelope;
        }

        public static Oscillator SetFrequency(this Oscillator oscillator, double frequency)
        {
            oscillator.Frequency = frequency;
            return oscillator;
        }

        public static Oscillator SetFrequency(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = oscillator;
            binding.Path = new PropertyPath("Frequency");
            target.SetBinding(property, binding);
            return oscillator;
        }

        public static Oscillator SetFrequencyModulationWaveForm(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = oscillator.FrequencyModulator;
            binding.Path = new PropertyPath("WaveForm");
            target.SetBinding(property, binding);
            return oscillator;
        }

        public static Oscillator SetFrequencyModulationWaveForm(this Oscillator oscillator, WaveForm waveForm)
        {
            oscillator.FrequencyModulator.WaveForm = waveForm;
            return oscillator;
        }

        public static Envelope SetRelease(this Envelope envelope, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = envelope;
            binding.Path = new PropertyPath("Release");
            target.SetBinding(property, binding);
            return envelope;
        }

        public static Envelope SetSustain(this Envelope envelope, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = envelope;
            binding.Path = new PropertyPath("Sustain");
            target.SetBinding(property, binding);
            return envelope;
        }


        public static Oscillator SetWaveForm(this Oscillator oscillator, FrameworkElement target, DependencyProperty property)
        {
            Binding binding = new Binding();
            binding.Mode = BindingMode.TwoWay;
            binding.Source = oscillator;
            binding.Path = new PropertyPath("WaveFormType");
            target.SetBinding(property, binding);
            return oscillator;
        }

        public static Oscillator SetWaveForm(this Oscillator oscillator, WaveForm waveForm)
        {
            oscillator.WaveFormType = waveForm;
            return oscillator;
        }
    }
}
