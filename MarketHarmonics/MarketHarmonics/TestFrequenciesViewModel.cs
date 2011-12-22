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
using System.Windows.Threading;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
namespace MarketHarmonics {
  public class TestFrequenciesViewModel : INotifyPropertyChanged {

    #region Class Members
    DispatcherTimer _Timer;
    MediaElement _MediaElement;
    int _currentIndex = 0;
    MediaElementState _MediaElementState;
    ISoundWaveGenerator _generator;
    #endregion
    
    #region Properties

    SimpleCommand _StartCommand;
    public ICommand StartCommand { get { return _StartCommand; } }
    List<double> _Frequencies;
    #endregion

    #region Constructor


    public TestFrequenciesViewModel() {
      Initialize();
    }
    #endregion

    #region Initialization
    private void Initialize() {
      _Frequencies = TestFrequencies.GetFrequencies();
      _generator = new OscillationSoundWave() { SoundWaveData = _Frequencies };
      _MediaElement = new MediaElement() { AutoPlay = false };
      _MediaElement.SetSource(_generator.Source);
      _currentIndex = 0;
      _Timer = new DispatcherTimer();
      _Timer.Interval = new TimeSpan( 0, 0, 1 );
      _Timer.Tick += _Timer_Tick;
      //_Track.PropertyChanged += _Track_PropertyChanged;
      _StartCommand = new SimpleCommand();
      _StartCommand.Executed += TestFrequenciesViewModel_Executed;
      _StartCommand.MayBeExecuted = true;
    }
    #endregion

    #region EventHandlers


    void TestFrequenciesViewModel_Executed( object sender, EventArgs e ) {
      _StartCommand.MayBeExecuted = false;
      _MediaElement.Play();
      _Timer.Start();
    }

    void _Timer_Tick( object sender, EventArgs e ) {
      if( _MediaElement.CurrentState == MediaElementState.Playing && _generator.HasNextValue() ) {
        _generator.NextValue();
      } else {
        _MediaElement.Stop();
        _generator.CurrentIndex = 0;
        _StartCommand.MayBeExecuted = true;
      }
      
    }
    #endregion

    #region INotifyPropertyChanged Implementation
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion
  }
}
