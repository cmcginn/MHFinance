using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using SilverSynth.Library;
using System.Collections.Generic;
namespace MarketHarmonics {
  public class OscillationSoundWave:ISoundWaveGenerator {

    public OscillationSoundWave() {
      Initialize();
    }
    MediaStreamSource _Source;
    Oscillator _oscillator;
    public int CurrentIndex { get; set; }
    public IEnumerable<double> SoundWaveData { get; set; }
    public bool HasNextValue() {
      return CurrentIndex< SoundWaveData.Count() - 1;
    }
    public void NextValue() {      
      _oscillator.Frequency = SoundWaveData.ElementAt( CurrentIndex);
      if(HasNextValue())
         CurrentIndex += 1;
    }
    void Initialize() {
      var spss = new StereoPcmStreamSource();
      _oscillator = new Oscillator() { Frequency = 0 };
      spss.Input = _oscillator;
      _Source = spss;
    }
    public MediaStreamSource Source {
      get { return _Source; }
      set {
        if( _Source == value )
          return;
        _Source = value;
      }
    }
  }
}
